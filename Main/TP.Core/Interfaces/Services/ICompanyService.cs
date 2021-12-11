using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TP.Core.Models;

namespace TP.Core.Interfaces.Services
{
    public interface ICompanyService
    {
        Task<IEnumerable<Company>> GetAllCompanies();
        Task<IEnumerable<Company>> GetAllCompanies(Expression<Func<Company, bool>> predicate);
        Task<Company> GetCompany(string id);
        Task<Company> AddCompany(Company company);
        Task<Company> UpdateCompany(Company company, string id);
        Task<bool> DeleteCompany(string id);
        Task<IEnumerable<Driver>> GetDrivers(string id);
        Task<IEnumerable<Vehicle>> GetVehicles(string id);
    }
}
