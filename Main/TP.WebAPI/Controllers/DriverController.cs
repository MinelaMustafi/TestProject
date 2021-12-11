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
    public class DriverController : ControllerBase
    {
        private readonly IDriverService driverService;

        public DriverController(IDriverService driverService)
        {
            this.driverService = driverService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<DriverModel>>> Get()
        {
            return (await driverService.GetAllDrivers()).Select(x => x.Create()).ToList();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<DriverModel>> Get(string id)
        {
            return (await driverService.GetDriver(id)).Create();
        }

        [HttpPost]
        public async Task<ActionResult<DriverModel>> Add([FromBody] Driver driver)
        {
            return (await driverService.AddDriver(driver)).Create();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<DriverModel>> Update([FromBody] Driver driver, string id)
        {
            return (await driverService.UpdateDriver(driver, id)).Create();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> Delete(string id)
        {
            return await driverService.DeleteDriver(id);
        }
    }
}
