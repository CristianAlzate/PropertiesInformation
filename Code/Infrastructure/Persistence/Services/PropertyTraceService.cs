using AutoMapper;
using Core.DTO.PropertyTrace;
using Core.Entities;
using Core.Interfaces.Base;
using Core.Interfaces.Repository;
using Core.Interfaces.Services;
using Infrastructure.Persistence.Data;
using Infrastructure.Persistence.Services.Base;
using Microsoft.Extensions.Configuration;

namespace Infrastructure.Persistence.Services
{
    public class PropertyTraceService : CRUDService<PropertyTraceDTO, CreatePropertyTraceDTO, UpdatePropertyTraceDTO, int, PropertyTrace,
        IPropertyTraceRepository<PropertiesInformationContext>, PropertiesInformationContext>, IPropertyTraceService
    {
        private readonly IConfiguration _config;

    public PropertyTraceService(IMapper mapper, IUnitOfWork<PropertiesInformationContext> unitOfWork, IPropertyTraceRepository<PropertiesInformationContext> propertyTraceRepository,
        IConfiguration configuration) :
        base(propertyTraceRepository, unitOfWork, mapper)
    {
        _config = configuration;
    }
    public async Task<CreatePropertyTraceDTO> InsertPropertyTraceAsync(CreatePropertyTraceDTO obj) => await InsertAsync(obj);
    }
}
