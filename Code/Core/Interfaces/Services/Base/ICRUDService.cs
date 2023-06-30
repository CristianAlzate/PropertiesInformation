using Core.Interfaces.Base;
using Core.Interfaces.Management;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces.Services.Base
{
    public interface ICRUDService<TGetDto,TAddDto,TUpdateDto,TKey,TEntity,TRepoAll,TContext>
        where TEntity : class, IEntityBase<TKey>
        where TRepoAll : IBaseRepository<TEntity,TContext>
        where TContext : DbContext, new()
    {
        Task<IEnumerable<TGetDto>> GetAllAsync(CancellationToken cancellationToken = default);
        Task<TGetDto> FindByIdAsync(int id, CancellationToken cancellationToken = default);
        Task<IEnumerable<TGetDto>> FilterAsync(Expression<Func<TEntity,bool>> predicate, CancellationToken cancellationToken = default);
        Task<TUpdateDto> UpdateAsync(TUpdateDto objDTO, CancellationToken cancellationToken = default);
        Task<TAddDto> InsertAsync(TAddDto objDTO, CancellationToken cancellationToken = default);
    }
}
