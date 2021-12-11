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
    public class VehicleController : ControllerBase
    {
        private readonly IVehicleService vehicleService;

        public VehicleController(IVehicleService vehicleService)
        {
            this.vehicleService = vehicleService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<VehicleModel>>> Get()
        {
            return (await vehicleService.GetAllVehicles()).Select(x => x.Create()).ToList();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<VehicleModel>> Get(string id)
        {
            return (await vehicleService.GetVehicle(id)).Create();
        }

        [HttpPost]
        public async Task<ActionResult<VehicleModel>> Add([FromBody] Vehicle vehicle)
        {
            return (await vehicleService.AddVehicle(vehicle)).Create();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<VehicleModel>> Update([FromBody] Vehicle vehicle, string id)
        {
            return (await vehicleService.UpdateVehicle(vehicle, id)).Create();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> Delete(string id)
        {
            return await vehicleService.DeleteVehicle(id);
        }
    }
}
