using AutoMapper;
using Core.DTO;
using Core.DTO.PropertyImage;
using Core.Entities;
using Core.Interfaces.Base;
using Core.Interfaces.Repository;
using Core.Interfaces.Services;
using Infrastructure.Persistence.Data;
using Infrastructure.Persistence.Repository;
using Infrastructure.Persistence.Services.Base;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Services
{
    public class PropertyImageService : CRUDService<PropertyImageDTO, CreatePropertyImageDTO, UpdatePropertyImageDTO, int, PropertyImage,
        IPropertyImageRepository<PropertiesInformationContext>, PropertiesInformationContext>, IPropertyImageService
    {
        private readonly IConfiguration _config;
        private readonly IFilesRepository _filesRepository;

        public PropertyImageService(IMapper mapper, IUnitOfWork<PropertiesInformationContext> unitOfWork, IPropertyImageRepository<PropertiesInformationContext> propertyImageRepository, 
            IConfiguration configuration, IFilesRepository filesRepository) :
            base(propertyImageRepository, unitOfWork, mapper)
        {
            _config = configuration;
            _filesRepository = filesRepository;
        }
        public async Task<CreatePropertyImageDTO> InsertPropertyImageAsync(CreatePropertyImageDTO objDTO, CancellationToken cancellationToken = default)
        {
            objDTO.FileUrl = string.Empty;
            var obj = await InsertAsync(objDTO, cancellationToken);
            string connectionstring = _config.GetConnectionString("BlobConnectionString");
            string container = _config.GetSection("AppSettings")["Container"];
            string filename = _config.GetSection("AppSettings")["PropertyFolder"] + "/" + obj.Id + "." + objDTO.Image?.ContentType.Split('/')[1];
            FileUploadProperties fileProperties = new FileUploadProperties(connectionstring, container);
            fileProperties.FileName = filename;
            using (fileProperties.memoryStream = new MemoryStream())
            {
                objDTO.Image?.CopyTo(fileProperties.memoryStream);
                fileProperties.memoryStream.Position = 0;
                fileProperties.ContentType = objDTO.Image?.ContentType;
                var uploadedFile = await _filesRepository.UploadImage(fileProperties);
                obj.FileUrl = _config.GetSection("AppSettings")["containerURL"] + container + "/" + filename;
                var propertyImageUpdate = _mapper.Map<UpdatePropertyImageDTO>(obj);
                if (!uploadedFile)
                    obj.FileUrl = "Error guardando la foto";
                await UpdateAsync(propertyImageUpdate);


            }
            return obj;
        }
    }
}
