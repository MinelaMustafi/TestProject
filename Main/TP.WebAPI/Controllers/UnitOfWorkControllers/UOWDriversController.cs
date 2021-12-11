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
    public class UOWDriversController : UOWBaseController
    {
        public UOWDriversController(Context context) : base(context) { }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok((await unit.Drivers.GetAsync()).Select(x => x.Create()).ToList());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            return Ok((await unit.Drivers.GetAsync(id)).Create());
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Driver driver)
        {
            await unit.Drivers.AddAsync(driver);
            await unit.Save();
            return Ok(driver.Create());
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put([FromBody] Driver driver, string id)
        {
            if (id != driver.ID) return BadRequest();
            await unit.Drivers.UpdateAsync(driver, id);
            await unit.Save();
            return Ok(driver.Create());
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            await unit.Drivers.Delete(id);
            await unit.Save();
            return NoContent();
        }
    }
}
