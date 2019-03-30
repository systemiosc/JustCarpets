using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JustCarpets.Models;

namespace JustCarpets.Interfaces
{
    public interface ICompanyService
    {
        Task<BaseServiceResponse<List<CompanyDto>>> GetAll();
        Task<BaseServiceResponse<CompanyDto>> GetById(int Id);
        Task<BaseServiceResponse<CompanyDto>> Add(CompanyDto model);
    }
}
