using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.DTO.Owner;

namespace Core.DTO.Property
{
    public class CreatePropertyDTO
    {
        public CreatePropertyDTO()
        {
            Owner = new CreateOwnerDTO();
        }
        public string Name { get; set; } = null!;
        public string Address { get; set; } = null!;
        public decimal Price { get; set; }
        public string CodeInternal { get; set; } = null!;
        public int Year { get; set; }
        public CreateOwnerDTO? Owner { get; set; } = null!;
    }
}
