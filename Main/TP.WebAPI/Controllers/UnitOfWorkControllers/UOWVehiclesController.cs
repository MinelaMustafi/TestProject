using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TP.Core.Models;
using TP.Infrastructure;
using TP.WebAPI.Factories;

namespace TP.WebAPI.Controllers.UnitOfWorkControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UOWVehiclesController : UOWBaseController
    {
        public UOWVehiclesController(Context context) : base(context) { }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok((await unit.Vehicles.GetAsync()).Select(x => x.Create()).ToList());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            return Ok((await unit.Vehicles.GetAsync(id)).Create());
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Vehicle vehicle)
        {
            await unit.Vehicles.AddAsync(vehicle);
            await unit.Save();
            return Ok(vehicle.Create());
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put([FromBody] Vehicle vehicle, string id)
        {
            if (id != vehicle.ID) return BadRequest();
            await unit.Vehicles.UpdateAsync(vehicle, id);
            await unit.Save();
            return Ok(vehicle.Create());
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            await unit.Vehicles.Delete(id);
            await unit.Save();
            return NoContent();
        }
    }
}
