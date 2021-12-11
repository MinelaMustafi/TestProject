using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TP.Core.Interfaces.Repositories;
using TP.Core.Interfaces.Services;
using TP.Core.Models;
using TP.Infrastructure.Repositories.EFCore;

namespace TP.Infrastructure.Serivces
{
    public class CompanyService : ICompanyService
    {
        private ICompanyRepository companyRepository;
        public CompanyService(ICompanyRepository companyRepository)
        {
            this.companyRepository = companyRepository;
        }

        public async Task<IEnumerable<Company>> GetAllCompanies()
        {
            return await companyRepository.GetAsync();
        }

        public async Task<IEnumerable<Company>> GetAllCompanies(Expression<Func<Company, bool>> predicate)
        {
            return await companyRepository.GetAsync(predicate);
        }

        public async Task<Company> GetCompany(string id)
        {
            return await companyRepository.GetAsync(id);
        }

        public async Task<Company> AddCompany(Company company)
        {
            Company c = await companyRepository.AddAsync(company);
            await companyRepository.Save();
            return c;
        }

        public async Task<Company> UpdateCompany(Company company, string id)
        {
            Company c = await companyRepository.UpdateAsync(company, id);
            await companyRepository.Save();
            return c;
        }

        public async Task<bool> DeleteCompany(string id)
        {
            bool deleted = await companyRepository.Delete(id);
            await companyRepository.Save();
            return deleted;
        }

        public async Task<IEnumerable<Driver>> GetDrivers(string id)
        {
            return await companyRepository.GetDriversAsync(id);
        }

        public async Task<IEnumerable<Vehicle>> GetVehicles(string id)
        {
            return await companyRepository.GetVehiclesAsync(id);
        }
    }
}
