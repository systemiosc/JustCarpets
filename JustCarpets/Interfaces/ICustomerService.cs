using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JustCarpets.Models;

namespace JustCarpets.Interfaces
{
    public interface ICustomerService
    {
        Task<BaseServiceResponse<CustomerDto>> GetCustomerAccount(string macAddress);
        Task<BaseServiceResponse<List<CustomerDto>>> GetCustomers();
        Task<BaseServiceResponse<Boolean>> UpdateCustomer(CustomerDto model);

    }
}
