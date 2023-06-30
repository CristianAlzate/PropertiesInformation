using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.DTO.Owner;
using Core.DTO.PropertyImage;
using Core.DTO.PropertyTrace;

namespace Core.DTO.Property
{
    public class PropertyDTO
    {
        public PropertyDTO()
        {
            Owner = new OwnerDTO();
        }
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Address { get; set; } = null!;
        public decimal Price { get; set; }
        public string CodeInternal { get; set; } = null!;
        public int Year { get; set; }
        public int IdOwner { get; set; }
        public OwnerDTO Owner { get; set; } = null!;
        public List<PropertyImageDTO> PropertyImages { get; set; } = null!;
        public List<PropertyTraceDTO> PropertyTraces { get; set; } = null!;
    }
}
