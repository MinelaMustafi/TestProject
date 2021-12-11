using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TP.Core.Interfaces.Repositories;
using TP.Core.Models;
using TP.Infrastructure.Repositories.EFCore;

namespace TP.Infrastructure
{
    public class UnitOfWork : IDisposable
    {
        public Context Context { get; }
        public UnitOfWork(Context context) => Context = context;

        private IRepository<Company> companies;
        private IRepository<Driver> drivers;
        private IRepository<Vehicle> vehicles;

        public IRepository<Company> Companies => companies ?? (companies = new CompanyRepository(Context));
        public IRepository<Driver> Drivers => drivers ?? (drivers = new Repository<Driver>(Context));
        public IRepository<Vehicle> Vehicles => vehicles ?? (vehicles = new Repository<Vehicle>(Context));

        public async Task Save()
        {
            await Context.SaveChangesAsync();
        }

        public void Dispose() => Context.Dispose();
    }
}
