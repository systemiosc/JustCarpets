using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using JustCarpets.Data;
using JustCarpets.Data.Entities;
using JustCarpets.Interfaces;
using JustCarpets.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace JustCarpets.Services
{
    public class CustomerService : ICustomerService
    {
        private JustCarpetDbContext _dbContext;
        private ILogger _logger;

        public CustomerService(ILogger<CustomerService> logger, JustCarpetDbContext context)
        {
            _logger = logger;
            _dbContext = context;
        }

        public async Task<BaseServiceResponse<CustomerDto>> GetCustomerAccount(string macAddress)
        {
            BaseServiceResponse<CustomerDto> response = new BaseServiceResponse<CustomerDto>();
            try
            {
                var existing = await _dbContext.Customers.Where(e => e.MacAddress == macAddress).SingleOrDefaultAsync();

                if (existing != null)
                {
                    response.Results = new CustomerDto()
                    {
                        Id = existing.Id,
                        Name = existing.Name ?? "",
                        Address = existing.Address ?? "",
                        MacAddress = existing.MacAddress
                    };

                    response.Success = true;
                }
                else
                {
                    //new customer 
                    CustomerEntity entity = new CustomerEntity()
                    {
                        MacAddress = macAddress,
                        Created = DateTime.Now
                    };

                    _dbContext.Customers.Add(entity);
                    await _dbContext.SaveChangesAsync();

                    response.Results = new CustomerDto()
                    {
                        MacAddress = entity.MacAddress,
                        Id = entity.Id
                    };

                    response.Success = true;

                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Customer Service Exception - Get Customer Account");
                response.Success = false;
                response.ErrorMessage = ex.ToString();
            }

            return response;
        }

        public async Task<BaseServiceResponse<List<CustomerDto>>> GetCustomers()
        {
            BaseServiceResponse<List<CustomerDto>> response = new BaseServiceResponse<List<CustomerDto>>();

            try
            {
                var customers = await _dbContext.Customers.ToListAsync();
                response.Results = customers.Select(e => new CustomerDto()
                {
                    Id = e.Id,
                    MacAddress = e.MacAddress,
                    Name = e.Name ?? "",
                    Address = e.Address ?? "",
                    EmailAddress = e.EmailAddress ?? ""
                }).ToList();

                response.Success = true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Customer Service exception - GetCustomers");
                response.Success = false;
                response.ErrorMessage = ex.ToString();
            }

            return response;

        }


        public async Task<BaseServiceResponse<bool>> UpdateCustomer(CustomerDto model)
        {
            BaseServiceResponse<Boolean> response = new BaseServiceResponse<bool>();

            try
            {

                CustomerEntity customer = new CustomerEntity();

                customer = await _dbContext.Customers.Where(e => e.MacAddress == model.MacAddress)
                    .SingleOrDefaultAsync();

                //existing or new still the same logic.

                customer.Address = model.Address;
                customer.Name = model.Name;
                customer.EmailAddress = model.EmailAddress;
                customer.TelephoneNumber = model.TelephoneNumber;
                customer.MacAddress = model.MacAddress;

                if (customer.Id == 0)
                    _dbContext.Customers.Add(customer);
                        
                await _dbContext.SaveChangesAsync();

                response.Success = true;
                response.Results = true;

            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Results = false;
                _logger.LogError(ex, "Customer Service - Update method threw exception");
                response.ErrorMessage = ex.ToString();
            }

            return response;

        }
    }
}
