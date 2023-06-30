using Core.Entities;
using Core.Interfaces.Base;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Core.Interfaces.Repository
{
    public interface IPropertyRepository<TContext> : IBaseRepository<Property, TContext> where TContext : DbContext, new()
    {
        Task<IEnumerable<Property>> GetPropertiesAsync(CancellationToken cancellationToken = default);
        Task<Property> GetPropertyAsync(int id, CancellationToken cancellationToken = default);
        Task<IEnumerable<Property>> FilterPropertyAsync(Expression<Func<Property, bool>> predicate, CancellationToken cancellationToken = default);
        Task<Property> AddPropertyAsync(Property obj, CancellationToken cancellationToken = default);
        void UpdateProperty(Property obj);
    }
}
