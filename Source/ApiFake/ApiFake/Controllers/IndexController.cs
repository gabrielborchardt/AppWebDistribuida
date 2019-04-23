using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiFake.Controllers
{
    [Route("")]
    [ApiController]
    public class IndexController : ControllerBase
    {
        [Route("")]
        [HttpGet]
        public IActionResult Index()
        {
            return Ok("Api em execução.");
        }
    }
}