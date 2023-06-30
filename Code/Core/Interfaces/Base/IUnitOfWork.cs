using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces.Base
{
    public interface IUnitOfWork<TContext> where TContext : DbContext, new()
    {
        void CreateTransaction();
        Task CreateTransactionAsync();
        Task CreateTransactionAsync(CancellationToken cancellationToken = default);
        void Rollback();
        Task RollbackAsync();
        Task RollbackAsync(CancellationToken cancellationToken = default);
        void Commit();
        Task CommitAsync(CancellationToken cancellationToken = default);
        Task CommitAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default);

    }
}
