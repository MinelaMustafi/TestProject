using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TP.Core.Models;

namespace TP.Core.Interfaces.Services
{
    public interface IVehicleService
    {
        Task<IEnumerable<Vehicle>> GetAllVehicles();
        Task<IEnumerable<Vehicle>> GetAllVehicles(Expression<Func<Vehicle, bool>> predicate);
        Task<Vehicle> GetVehicle(string id);
        Task<Vehicle> AddVehicle(Vehicle vehicle);
        Task<Vehicle> UpdateVehicle(Vehicle vehicle, string id);
        Task<bool> DeleteVehicle(string id);
    }
}
