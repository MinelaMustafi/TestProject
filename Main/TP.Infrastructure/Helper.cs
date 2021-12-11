using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TP.Core.Models;

namespace TP.Infrastructure
{
    public static class Helper
    {
        public static void Create<T>(this T entity, Context context)
        {
            if (typeof(T) == typeof(Driver)) BuildLink(entity as Driver, context);
            if (typeof(T) == typeof(Vehicle)) BuildLink(entity as Vehicle, context);
        }
        #region
        public static void BuildLink(Driver driver, Context context)
        {
            driver.Company = context.Companies.Find(driver.Company.ID);
        }

        public static void BuildLink(Vehicle vehicle, Context context)
        {
            vehicle.Company = context.Companies.Find(vehicle.Company.ID);
        }
        #endregion

        public static async Task CreateAsync<T>(this T entity, Context context)
        {
            if (typeof(T) == typeof(Driver)) await BuildLinkAsync(entity as Driver, context);
            if (typeof(T) == typeof(Vehicle)) await BuildLinkAsync(entity as Vehicle, context);
        }
        #region
        public static async Task BuildLinkAsync(Driver driver, Context context)
        {
            driver.Company = await context.Companies.FindAsync(driver.Company.ID);
        }

        public static async Task BuildLinkAsync(Vehicle vehicle, Context context)
        {
            vehicle.Company = await context.Companies.FindAsync(vehicle.Company.ID);
        }
        #endregion

        public static void Update<T>(this T oldEntity, T newEntity)
        {
            if (typeof(T) == typeof(Driver)) UpdateLink(oldEntity as Driver, newEntity as Driver);
            if (typeof(T) == typeof(Vehicle)) UpdateLink(oldEntity as Vehicle, newEntity as Vehicle);
        }
        #region
        public static void UpdateLink(Driver oldDriver, Driver newDriver)
        {
            oldDriver.Company = newDriver.Company;
        }

        public static void UpdateLink(Vehicle oldVehicle, Vehicle newVehicle)
        {
            oldVehicle.Company = newVehicle.Company;
        }
        #endregion

        public static bool CanDelete<T>(this T entity)
        {
            if (typeof(T) == typeof(Company)) return HasNoChildren(entity as Company);
            return true;
        }
        #region
        public static bool HasNoChildren(Company company)
        {
            return company.Drivers.Count + company.Vehicles.Count == 0;
        }
        #endregion
    }
}
