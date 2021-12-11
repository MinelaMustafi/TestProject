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
    public class VehicleService : IVehicleService
    {
        private IRepository<Vehicle> vehicleRepository;
        public VehicleService(IRepository<Vehicle> vehicleRepository)
        {
            this.vehicleRepository = vehicleRepository;
        }

        public async Task<IEnumerable<Vehicle>> GetAllVehicles()
        {
            return await vehicleRepository.GetAsync();
        }

        public async Task<IEnumerable<Vehicle>> GetAllVehicles(Expression<Func<Vehicle, bool>> predicate)
        {
            return await vehicleRepository.GetAsync(predicate);
        }

        public async Task<Vehicle> GetVehicle(string id)
        {
            return await vehicleRepository.GetAsync(id);
        }

        public async Task<Vehicle> AddVehicle(Vehicle vehicle)
        {
            Vehicle v = await vehicleRepository.AddAsync(vehicle);
            await vehicleRepository.Save();
            return v;
        }

        public async Task<Vehicle> UpdateVehicle(Vehicle vehicle, string id)
        {
            Vehicle v = await vehicleRepository.UpdateAsync(vehicle, id);
            await vehicleRepository.Save();
            return v;
        }

        public async Task<bool> DeleteVehicle(string id)
        {
            bool deleted = await vehicleRepository.Delete(id);
            await vehicleRepository.Save();
            return deleted;
        }
    }
}
