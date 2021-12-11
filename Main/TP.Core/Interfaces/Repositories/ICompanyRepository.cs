using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TP.Core.Models;

namespace TP.Core.Interfaces.Repositories
{
    public interface ICompanyRepository : IRepository<Company>
    {
        IEnumerable<Driver> GetDrivers(string id);
        Task<IEnumerable<Driver>> GetDriversAsync(string id);
        IEnumerable<Vehicle> GetVehicles(string id);
        Task<IEnumerable<Vehicle>> GetVehiclesAsync(string id);
    }
}
