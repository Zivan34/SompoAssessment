using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessObjects.GlobalClasses
{
    public class ApiResponse<T>
    {
        public Exception Exception { get; set; }
        public string Message { get; set; }
        public bool IsSucccess { get; set; }
        public T Data { get; set; }

        public ApiResponse<T> Success(string message = "İstek başarılı")
        {
            this.IsSucccess = true;
            this.Message = message;
            return this;
        }

        public ApiResponse<T> Error(Exception exception, string message = "İstek başarısız")
        {
            this.IsSucccess = false;
            this.Message = message;
            this.Exception = exception;
            return this;
        }
    }
}
