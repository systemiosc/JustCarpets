using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JustCarpets.Data;
using JustCarpets.Interfaces;
using JustCarpets.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace JustCarpets.Services
{
    public class CompanyService : ICompanyService
    {
        private JustCarpetDbContext _dbContext;
        private ILogger _logger;

        public CompanyService(JustCarpetDbContext context, ILogger<CompanyService> logger)
        {
            _dbContext = context;
            _logger = logger;
        }

        public async Task<BaseServiceResponse<List<CompanyDto>>> GetAll()
        {
            BaseServiceResponse<List<CompanyDto>> serviceResponse = new BaseServiceResponse<List<CompanyDto>>();

            try
            {
                var data = await _dbContext.Companies.ToListAsync();

                serviceResponse.Results = data.Select(e => new CompanyDto()
                {
                    Id=e.Id,
                    Name = e.Name,
                    Email = e.Email,
                    Website = e.Website,
                    Telephone = e.Telephone
                }).ToList();

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Company Service - Get All Companies threw exception.");
                serviceResponse.Success = false;
                serviceResponse.ErrorMessage = ex.ToString();
            }

            return serviceResponse;
        }

        public Task<BaseServiceResponse<CompanyDto>> GetById(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<BaseServiceResponse<CompanyDto>> Add(CompanyDto model)
        {
            throw new NotImplementedException();
        }
    }
}
