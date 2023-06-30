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
    public class PropertyImageRepository : BaseRepository<PropertyImage, int, PropertiesInformationContext>,IPropertyImageRepository<PropertiesInformationContext>
    {
        public PropertyImageRepository(IDbFactory<PropertiesInformationContext> dbFactory) : base(dbFactory) { }
    }
}
