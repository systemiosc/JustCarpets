using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JustCarpets.Models
{
    public class BaseServiceResponse<T>
    {
        public T Results { get; set; }
        public string ErrorMessage { get; set; }
        public bool Success { get; set; }
    }
}
