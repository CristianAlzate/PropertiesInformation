using Core.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces.Repository
{
    public interface IFilesRepository
    {
        Task<bool> UploadImage(FileUploadProperties fileProperties);
    }
}
