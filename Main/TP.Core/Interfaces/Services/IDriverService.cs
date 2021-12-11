using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TP.Core.Models;

namespace TP.Core.Interfaces.Services
{
    public interface IDriverService
    {
        Task<IEnumerable<Driver>> GetAllDrivers();
        Task<IEnumerable<Driver>> GetAllDrivers(Expression<Func<Driver, bool>> predicate);
        Task<Driver> GetDriver(string id);
        Task<Driver> AddDriver(Driver driver);
        Task<Driver> UpdateDriver(Driver driver, string id);
        Task<bool> DeleteDriver(string id);
    }
}
