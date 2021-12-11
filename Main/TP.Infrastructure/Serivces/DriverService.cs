using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TP.Core.Interfaces.Repositories;
using TP.Core.Interfaces.Services;
using TP.Core.Models;

namespace TP.Infrastructure.Serivces
{
    public class DriverService : IDriverService
    {
        private IRepository<Driver> driverRepository;
        public DriverService(IRepository<Driver> driverRepository)
        {
            this.driverRepository = driverRepository;
        }

        public async Task<IEnumerable<Driver>> GetAllDrivers()
        {
            return await driverRepository.GetAsync();
        }

        public async Task<IEnumerable<Driver>> GetAllDrivers(Expression<Func<Driver, bool>> predicate)
        {
            return await driverRepository.GetAsync(predicate);
        }

        public async Task<Driver> GetDriver(string id)
        {
            return await driverRepository.GetAsync(id);
        }

        public async Task<Driver> AddDriver(Driver driver)
        {
            Driver d = await driverRepository.AddAsync(driver);
            await driverRepository.Save();
            return d;
        }

        public async Task<Driver> UpdateDriver(Driver driver, string id)
        {
            Driver d = await driverRepository.UpdateAsync(driver, id);
            await driverRepository.Save();
            return d;
        }

        public async Task<bool> DeleteDriver(string id)
        {
            bool deleted = await driverRepository.Delete(id);
            await driverRepository.Save();
            return deleted;
        }
    }
}
