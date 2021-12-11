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
    public class UOWCompaniesController : UOWBaseController
    {
        public UOWCompaniesController(Context context) : base(context) { }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok((await unit.Companies.GetAsync()).Select(x => x.Create()).ToList());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            return Ok((await unit.Companies.GetAsync(id)).Create());
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Company company)
        {
            await unit.Companies.AddAsync(company);
            await unit.Save();
            return Ok(company.Create());
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put([FromBody] Company company, string id)
        {
            if (id != company.ID) return BadRequest();
            await unit.Companies.UpdateAsync(company, id);
            await unit.Save();
            return Ok(company.Create());
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            await unit.Companies.Delete(id);
            await unit.Save();
            return NoContent();
        }
    }
}
