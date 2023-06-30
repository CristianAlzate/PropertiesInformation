using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces.Base
{
    public interface IBaseRepository<T,TContext> : IReadRepository<T,TContext>
        where T : class
        where TContext : DbContext, new()
    {
        Task AddAsync(T entity, CancellationToken cancellationToken = default);
        void Update(T entity);
    }
}
