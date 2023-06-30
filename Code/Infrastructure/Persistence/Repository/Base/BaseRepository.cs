using Core.Interfaces.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Repository.Base
{
    public class BaseRepository<T, TKey, TContext> : IBaseRepository<T, TContext>
        where T : class
        where TContext : DbContext, new()
    {
        private TContext _dataContext;
        private DbSet<T> _dbSet;
        private IQueryable<T> _query;

        protected IDbFactory<TContext> DbFactory { get; private set; }

        protected TContext DbContext { get => _dataContext ?? (_dataContext = DbFactory.Init()); }

        public BaseRepository(IDbFactory<TContext> dbFactory) { DbFactory = dbFactory; _dbSet = DbContext.Set<T>(); _query = DbContext.Set<T>(); }

        public async Task AddAsync(T entity, CancellationToken cancellationToken = default) =>
            await _dbSet.AddAsync(entity, cancellationToken);

        public void Update(T Entity) => _dbSet.Update(Entity);

        public async Task<IEnumerable<T>> GetAllAsync(CancellationToken cancellationToken = default) =>
            await _query.ToListAsync(cancellationToken);

        public BaseRepository<T, TKey,TContext> Include(string navigationPropertyPath)
        {
            _query = _dbSet.Include(navigationPropertyPath);
            return this;
        }

        public async Task<T> GetByIdAsync(int id, CancellationToken cancellationToken = default) =>
            await _dbSet.FindAsync(new object[] { id }, cancellationToken);

        public async Task<IEnumerable<T>> FilterAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default) =>
            await _query.Where(predicate).ToListAsync(cancellationToken);
    }
}
