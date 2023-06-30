using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DTO.PropertyImage
{
    public class UpdatePropertyImageDTO
    {
        public int Id { get; set; }
        public string FileUrl { get; set; } = null!;
    }
}
