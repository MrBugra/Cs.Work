using System;
using System.Collections.Generic;
using System.Text;

namespace Cs.Basket.Core.Models
{
    public class ApiResponse
    {
        public string Message { get; set; }
        public int Code { get; set; }
    }
    public class ApiResponse<T>
    {
        public string Message { get; set; }
        public int Code { get; set; }
        public T Data { get; set; }
    }
}
