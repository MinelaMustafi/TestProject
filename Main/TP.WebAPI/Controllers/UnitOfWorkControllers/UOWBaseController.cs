using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TP.Infrastructure;

namespace TP.WebAPI.Controllers.UnitOfWorkControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UOWBaseController : ControllerBase
    {
        protected UnitOfWork unit;

        public UOWBaseController(Context context)
        {
            unit = new UnitOfWork(context);
        }
    }
}
