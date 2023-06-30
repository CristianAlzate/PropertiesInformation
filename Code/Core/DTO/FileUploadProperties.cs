using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DTO
{
    public class FileUploadProperties
    {
        public FileUploadProperties(string _connectionString,string _container) 
        { 
            containerProperties = new ContainerProperties(_connectionString, _container); 

        }
        public string FileName { get; set; }
        public string ContentType { get; set; }
        public MemoryStream memoryStream { get; set; }
        public ContainerProperties containerProperties { get; set; }
        
    }

    public class ContainerProperties
    {
        public ContainerProperties(string _connectionString, string _container)
        {
            ConnectionString = _connectionString;
            Container = _container;
        }
        public string ConnectionString { get; set;}
        public string Container { get; set; }
    }
}
