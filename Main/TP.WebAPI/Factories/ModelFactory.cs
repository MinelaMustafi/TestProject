using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TP.Core.Models;
using TP.WebAPI.ViewModels;

namespace TP.WebAPI.Factories
{
    public static class ModelFactory
    {
        public static CompanyModel Create(this Company company)
        {
            return new CompanyModel
            {
                ID = company.ID,
                Name = company.Name
            };
        }

        public static DriverModel Create(this Driver driver)
        {
            return new DriverModel
            {
                ID = driver.ID,
                Name = driver.Name,
                Company = driver.Company.Create()
            };
        }

        public static VehicleModel Create(this Vehicle vehicle)
        {
            return new VehicleModel
            {
                ID = vehicle.ID,
                Name = vehicle.Name,
                Company = vehicle.Company.Create()
            };
        }
    }
}
