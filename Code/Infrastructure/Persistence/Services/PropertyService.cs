using AutoMapper;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Core.DTO;
using Core.DTO.Property;
using Core.Entities;
using Core.Interfaces.Base;
using Core.Interfaces.Repository;
using Core.Interfaces.Services;
using Infrastructure.Persistence.Data;
using Infrastructure.Persistence.Repository;
using Infrastructure.Persistence.Services.Base;
using Microsoft.Extensions.Azure;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Services
{
    public class PropertyService : CRUDService<PropertyDTO, CreatePropertyDTO, UpdatePropertyDTO, int, Property,
        IPropertyRepository<PropertiesInformationContext>, PropertiesInformationContext>, IPropertyService
    {
        private readonly IOwnerRepository<PropertiesInformationContext> _ownerRepository;
        private readonly IConfiguration _config;
        private readonly IFilesRepository _filesRepository;

        public PropertyService(IMapper mapper, IUnitOfWork<PropertiesInformationContext> unitOfWork, IPropertyRepository<PropertiesInformationContext> propertyRepository, IOwnerRepository<PropertiesInformationContext> ownerRepository,
            IConfiguration configuration, IFilesRepository filesRepository) :
            base(propertyRepository, unitOfWork, mapper)
        {
            _ownerRepository = ownerRepository;
            _config = configuration;
            _filesRepository = filesRepository;
        }

        public async Task<PropertyDTO> FindPropertyAsync(int id, CancellationToken cancellationToken = default) =>
            await FindByIdAsync(id, cancellationToken);

        public async Task<IEnumerable<PropertyDTO>> GetProperties(CancellationToken cancellationToken = default) 
        {
            var _properties = await _repository.GetPropertiesAsync(cancellationToken);
            return _mapper.Map<IEnumerable<PropertyDTO>>(_properties);
        }

        /// <summary>
        /// Metodo para filtrar propiedades
        /// </summary>
        /// <param name="name"></param>
        /// <param name="idOwner"></param>
        /// <param name="price"></param>
        /// <param name="address"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<IEnumerable<PropertyDTO>> GetProperties(string? name, int? idOwner, decimal? price, string? address, CancellationToken cancellationToken = default)
        {
            Expression<Func<Property, bool>> filter = s => (!string.IsNullOrEmpty(name) ? s.Name.Contains(name) : s.Name == s.Name)
                                                        && (!string.IsNullOrEmpty(address) ? s.Address.Contains(address) : s.Address == s.Address)
                                                        && (idOwner != null ? s.IdOwner == idOwner : s.IdOwner == s.IdOwner)
                                                        && (price != null ? s.Price > price : s.Price == s.Price)  ;
                                                                    ;
            var _properties = await _repository.FilterPropertyAsync(filter, cancellationToken);
            return _mapper.Map<IEnumerable<PropertyDTO>>(_properties);
        }

        /// <summary>
        /// Metodo que inserta la propiedad y a su propietario en caso tal de que no exista
        /// </summary>
        /// <param name="objDTO"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<CreatePropertyDTO> InsertPropertyAsync(CreatePropertyDTO objDTO, CancellationToken cancellationToken = default) 
        {
            if (objDTO.Owner.IdOwner == 0)
            {
                var obj = await InsertAsync(objDTO, cancellationToken);
                
                string connectionstring = _config.GetConnectionString("BlobConnectionString");
                string container = _config.GetSection("AppSettings")["Container"];
                string filename = _config.GetSection("AppSettings")["OwnerFolder"] + "/" + obj.Owner?.IdOwner + "." + objDTO.Owner?.PhotoFile?.ContentType.Split('/')[1];
                FileUploadProperties fileProperties = new FileUploadProperties(connectionstring, container);
                fileProperties.FileName = filename;
                using (fileProperties.memoryStream = new MemoryStream())
                {
                    objDTO.Owner?.PhotoFile?.CopyTo(fileProperties.memoryStream);
                    fileProperties.memoryStream.Position = 0;
                    var uploadedFile = await _filesRepository.UploadImage(fileProperties);
                    obj.Owner.Photo = _config.GetSection("AppSettings")["containerURL"] + container + "/"+ filename;
                    var ownerUpdate = _mapper.Map<Owner>(obj.Owner);
                    if (uploadedFile)
                        obj.Owner.Photo = _config.GetSection("AppSettings")["containerURL"] + container + "/" + filename;
                    else obj.Owner.Photo = "Error guardando la foto";
                    ownerUpdate.Id = obj.Owner.IdOwner;
                    await _ownerRepository.UpdateOwner(ownerUpdate);


                }
                return obj;
            }
            else
            {
                var entity = _mapper.Map<Property>(objDTO);
                entity.IdOwnerNavigation = null;
                entity.IdOwner = objDTO.Owner.IdOwner;
                var obj = await _repository.AddPropertyAsync(entity);
                return _mapper.Map<CreatePropertyDTO>(obj);
            }
                
        }
            

        public async Task<UpdatePropertyDTO> UpdatePropertyAsync(UpdatePropertyDTO objDTO, CancellationToken cancellationToken = default)=>
            await UpdateAsync(objDTO, cancellationToken);
    }
}
