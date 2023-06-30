using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DTO.PropertyImage
{
    public class PropertyImageDTO
    {
        public int Id { get; set; }
        public int IdProperty { get; set; }
        public string FileUrl { get; set; } = null!;
        public bool Enabled { get; set; }
    }
}
