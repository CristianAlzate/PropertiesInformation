using Core.DTO.Property;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces.Services
{
    public interface IPropertyService
    {
        Task<PropertyDTO> FindPropertyAsync(int id, CancellationToken cancellationToken = default);
        Task<IEnumerable<PropertyDTO>> GetProperties(CancellationToken cancellationToken = default);
        Task<IEnumerable<PropertyDTO>> GetProperties(string name, int? idOwner, decimal? price, string address, CancellationToken cancellationToken = default);
        Task<CreatePropertyDTO> InsertPropertyAsync(CreatePropertyDTO objDTO, CancellationToken cancellationToken = default);
        Task<UpdatePropertyDTO> UpdatePropertyAsync(UpdatePropertyDTO objDTO, CancellationToken cancellationToken = default);
    }
}
