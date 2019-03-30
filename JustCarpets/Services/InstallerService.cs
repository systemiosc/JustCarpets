using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using JustCarpets.Data;
using JustCarpets.Interfaces;
using JustCarpets.Models;
using Microsoft.AspNetCore.Identity.UI.Pages.Internal.Account;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace JustCarpets.Services
{
    public class InstallerService : IInstallerService
    {
        private JustCarpetDbContext _dbContext;
        private ILogger _logger;

        public InstallerService(JustCarpetDbContext context, ILogger<InstallerService> logger)
        {
            _dbContext = context;
            _logger = logger;
        }


        public async Task<BaseServiceResponse<List<InstallerAppointmentsDto>>> GetInstallerAppointments(int Id)
        {
            var response = new BaseServiceResponse<List<InstallerAppointmentsDto>>();

            try
            {
                var appointments = await _dbContext.InstallerAppointments.Where(e => e.InstallerId == Id).ToListAsync();

                response.Results = appointments.Select(e => new InstallerAppointmentsDto()
                {
                    Date = e.Date,
                    AM = e.AM
                }).ToList();

            }
            catch (Exception ex)
            {
                response.Success = false;
                response.ErrorMessage = ex.ToString();
                _logger.LogError(ex , "Installer Service - Get Installer Appointments threw an exception.");
            }
            return response;
        }

        public async Task<BaseServiceResponse<InstallerDetailsDto>> GetInstallerDetails(int id)
        {
            BaseServiceResponse<InstallerDetailsDto> response = new BaseServiceResponse<InstallerDetailsDto>();
            try
            {
                var installer = await _dbContext.CompanyLocations.Where(e => e.Id == id).Include(e => e.Company).Include(e => e.Rates)
                    .SingleOrDefaultAsync();

                response.Results = new InstallerDetailsDto()
                {
                    LocationId = installer.Id,
                    CompanyId = installer.CompanyId,
                    Name = installer.Company.Name,
                    Telephone = installer.Company.Telephone,
                    Email = installer.Company.Email,
                    Rating = 5,
                    LocationName = installer.LocationName,
                    Rates = installer.Rates.Select(e => new InstallerRatesDto()
                    {
                        Id = e.Id,
                        Type = e.Type,
                        Price = e.HalfDayRate
                    }).ToList()
                };
                response.Success = true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Installer Service Exception GetInstallerDetails");
                response.Success = false;
                response.ErrorMessage = ex.ToString();
            }

            return response;
        }

        public async Task<BaseServiceResponse<List<InstallerDto>>> GetInstallers()
        {
            BaseServiceResponse<List<InstallerDto>> response = new BaseServiceResponse<List<InstallerDto>>();

            try
            {
                var locations = await _dbContext.CompanyLocations.Where(e => e.Type == LocationType.Installer).Include(r => r.Company)
                    .ToListAsync();

                response.Results = locations.Select(e => new InstallerDto()
                {
                   LocationId = e.Id,
                    CompanyId = e.CompanyId,
                    Name = e.Company.Name,
                    Telephone = e.Company.Telephone,
                    Email = e.Company.Email,
                    Rating = 5
                }).ToList();

                response.Success = true;

            }
            catch (Exception ex)
            {
                response.Success = false;
                response.ErrorMessage = ex.ToString();
                _logger.LogError(ex,"Get Installers Method in Installer Service threw an exception.");
            }

            return response;
        }
    }
}
