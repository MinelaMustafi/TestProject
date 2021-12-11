using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TP.Core.Interfaces.Repositories;
using TP.Core.Models;

namespace TP.Infrastructure.Repositories.EFCore
{
    public class CompanyRepository : Repository<Company>, ICompanyRepository
    {
        public CompanyRepository(Context context) : base(context) { }

        public IEnumerable<Driver> GetDrivers(string id)
        {
            try
            {
                return dbSet.Find(id).Drivers.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception($"Couldn't retrieve entities from database: {ex.Message}");
            }
        }

        public async Task<IEnumerable<Driver>> GetDriversAsync(string id)
        {
            try
            {
                Company company = await dbSet.FindAsync(id);
                return company.Drivers.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception($"Couldn't retrieve entities from database: {ex.Message}");
            }
        }

        public IEnumerable<Vehicle> GetVehicles(string id)
        {
            try
            {
                return dbSet.Find(id).Vehicles.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception($"Couldn't retrieve entities from database: {ex.Message}");
            }
        }

        public async Task<IEnumerable<Vehicle>> GetVehiclesAsync(string id)
        {
            try
            {
                Company company = await dbSet.FindAsync(id);
                return company.Vehicles.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception($"Couldn't retrieve entities from database: {ex.Message}");
            }
        }
    }
}
