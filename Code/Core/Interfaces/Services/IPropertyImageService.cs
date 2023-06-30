using Core.DTO.PropertyImage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces.Services
{
    public interface IPropertyImageService
    {
        Task<CreatePropertyImageDTO> InsertPropertyImageAsync(CreatePropertyImageDTO objDTO, CancellationToken cancellationToken = default);
    }
}
