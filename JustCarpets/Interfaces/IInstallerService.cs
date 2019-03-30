using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JustCarpets.Models;

namespace JustCarpets.Interfaces
{
    public interface IInstallerService
    {
        Task<BaseServiceResponse<List<InstallerDto>>> GetInstallers();
        Task<BaseServiceResponse<List<InstallerAppointmentsDto>>> GetInstallerAppointments(int Id);
        Task<BaseServiceResponse<InstallerDetailsDto>> GetInstallerDetails(int id);
    }
}
