using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroCafeAdmin.Core.Generic
{
    public class SpResult<T>
    {
        public bool Success { get; set; } = true;
        public string Mensaje { get; set; } = "OK";
        public int Error { get; set; } = 0;
        public T Data { get; set; }
    }

    // Clase para respuestas API estandarizadas
    public class ApiResponse<T>
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public T Data { get; set; }
        public int? ErrorCode { get; set; }

        public ApiResponse()
        {
            Success = true;
            Message = "OK";
        }
    }
}
