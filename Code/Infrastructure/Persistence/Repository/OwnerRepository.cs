using Core.Entities;
using Core.Interfaces.Base;
using Core.Interfaces.Repository;
using Infrastructure.Persistence.Data;
using Infrastructure.Persistence.Repository.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Repository
{
    public class OwnerRepository : BaseRepository<Owner, int, PropertiesInformationContext>, IOwnerRepository<PropertiesInformationContext>
    {
        public OwnerRepository(IDbFactory<PropertiesInformationContext> dbFactory) : base(dbFactory) { }

        public async Task UpdateOwner(Owner obj) {
            var entity = await GetByIdAsync(obj.Id);
            entity.Photo = obj.Photo;
            DbContext.SaveChanges();
        }
    }
}
