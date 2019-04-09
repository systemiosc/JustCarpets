using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JustCarpets.Models;

namespace JustCarpets.Interfaces
{
    public interface IOrderService
    {
        Task<BaseServiceResponse<List<Order>>> GetOrders();
        Task<BaseServiceResponse<Order>> GetDetails(int id);

    }
}
