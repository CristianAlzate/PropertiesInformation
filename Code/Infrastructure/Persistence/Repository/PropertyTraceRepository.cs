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
    public class PropertyTraceRepository : BaseRepository<PropertyTrace, int, PropertiesInformationContext>, IPropertyTraceRepository<PropertiesInformationContext>
    {
        public PropertyTraceRepository(IDbFactory<PropertiesInformationContext> dbFactory) : base(dbFactory) { }
    }
}
