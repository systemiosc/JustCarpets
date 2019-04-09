using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using JustCarpets.Data;
using JustCarpets.Interfaces;
using JustCarpets.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace JustCarpets.Services
{
    public class OrderService : IOrderService
    {
        private JustCarpetDbContext _dbContext;
        private ILogger _logger;

        public OrderService(JustCarpetDbContext dbContext, ILogger<OrderService> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }

        public Task<BaseServiceResponse<Order>> GetDetails(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<BaseServiceResponse<List<Order>>> GetOrders()
        {
           BaseServiceResponse<List<Order>> response = new BaseServiceResponse<List<Order>>();

            try
            {

                var orders =await  _dbContext.Orders.Include(e => e.Customer).Include(e => e.OrderLines).ToListAsync();

                response.Results = orders.Select(e => new Order()
                {
                    Id = e.Id,
                    Created = e.Created,
                    TotalPrice = e.TotalPrice,
                    CustomerId = e.CustomerId,
                    ReviewDate = e.ReviewDate,
                    InstallerReviewId = e.InstallerReviewId,
                    Customer = new CustomerDto()
                    {
                        Id = e.CustomerId,
                        Name = e.Customer.Name,
                        Address = e.Customer.Address,
                        EmailAddress = e.Customer.EmailAddress
                    },
                    OrderLines = e.OrderLines.Select(o => new OrderLine()
                    {
                        Id = o.Id,
                        CarpetId = o.CarpetId,
                        CarpetSizeOptionId = o.CarpetSizeOptionId,
                        Qty = o.Qty
                    }).ToList()
                }).ToList();

                response.Success = true;
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Gt Order threw exception.");
                response.Success = false;
            }

            return response;
        }
    }
}
