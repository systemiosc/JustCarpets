using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JustCarpets.Models;

namespace JustCarpets.Interfaces
{
    public interface IFlooringService
    {
        Task<FlooringServiceResponse> GetFlooring(SearchParametersDto search);
        Task<FlooringServiceResponse> GetById(int Id);
    }
}
