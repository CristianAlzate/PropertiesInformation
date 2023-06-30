using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Wrappers
{
    public class APIResponse<T>
    {
        public APIResponse()
        {
            
        }
        public APIResponse(string message)
        {
            Succeded = true;
            Message = message;
        }

        public APIResponse(T data, string message = null)
        {
            Succeded = true;
            Message = message;
            Data = data;
        }

        public bool Succeded { get; set; }
        public string Message { get; set; }
        public List<string> Errors { get; set; }
        public T Data { get; set; }
    }
}
