using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TP.Core.Interfaces.Services;
using TP.Core.Models;
using TP.WebAPI.Factories;
using TP.WebAPI.ViewModels;

namespace TP.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly ICompanyService companyService;

        public CompanyController(ICompanyService companyService)
        {
            this.companyService = companyService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CompanyModel>>> Get()
        {
            return (await companyService.GetAllCompanies()).Select(x => x.Create()).ToList();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CompanyModel>> Get(string id)
        {
            return (await companyService.GetCompany(id)).Create();
        }

        [HttpPost]
        public async Task<ActionResult<CompanyModel>> Add([FromBody] Company company)
        {
            return (await companyService.AddCompany(company)).Create();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<CompanyModel>> Update([FromBody] Company company, string id)
        {
            return (await companyService.UpdateCompany(company, id)).Create();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> Delete(string id)
        {
            return await companyService.DeleteCompany(id);
        }

        [HttpGet("drivers/{id}")]
        public async Task<ActionResult<IEnumerable<DriverModel>>> GetDrivers(string id)
        {
            return (await companyService.GetDrivers(id)).Select(x => x.Create()).ToList();
        }

        [HttpGet("vehicles/{id}")]
        public async Task<ActionResult<IEnumerable<VehicleModel>>> GetVehicles(string id)
        {
            return (await companyService.GetVehicles(id)).Select(x => x.Create()).ToList();
        }
    }
}
