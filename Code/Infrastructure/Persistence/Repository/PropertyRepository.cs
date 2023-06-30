using AutoMapper;
using Core.DTO.Property;
using Core.Entities;
using Core.Interfaces.Base;
using Core.Interfaces.Repository;
using Infrastructure.Persistence.Base;
using Infrastructure.Persistence.Data;
using Infrastructure.Persistence.Repository.Base;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Infrastructure.Persistence.Repository
{
    public class PropertyRepository : BaseRepository<Property,int,PropertiesInformationContext>,IPropertyRepository<PropertiesInformationContext>
    {
        public PropertyRepository(IDbFactory<PropertiesInformationContext> dbFactory) : base(dbFactory) { }

        public async Task<Property> AddPropertyAsync(Property obj, CancellationToken cancellationToken = default) {
            await AddAsync(obj, cancellationToken);
            await DbContext.SaveChangesAsync();
            return obj;
        } 

        public async Task<IEnumerable<Property>> FilterPropertyAsync(Expression<Func<Property, bool>> predicate, CancellationToken cancellationToken = default) 
        {
            return await DbContext.Properties.Include("IdOwnerNavigation")
                                             .Include("PropertyTraces")
                                             .Include("PropertyImages").Where(predicate).ToListAsync();

        }
            

        public async Task<IEnumerable<Property>> GetPropertiesAsync(CancellationToken cancellationToken = default) 
        {
            return await DbContext.Properties.Include("IdOwnerNavigation")
                                             .Include("PropertyImages")
                                             .Include("PropertyTraces").ToListAsync();

        }
            

        public async Task<Property> GetPropertyAsync(int id, CancellationToken cancellationToken = default) => 
            await GetByIdAsync(id,cancellationToken);

        public void UpdateProperty(Property obj) => Update(obj);
    }
}
