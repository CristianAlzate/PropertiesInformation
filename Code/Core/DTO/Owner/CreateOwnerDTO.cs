using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DTO.Owner
{
    public class CreateOwnerDTO
    {
        public int IdOwner { get; set; }
        public string? Name { get; set; }
        public string? Address { get; set; }
        public IFormFile? PhotoFile { get; set; }
        public string? Photo { get; set; }
        public DateTime? Birthday { get; set; }
    }
}
