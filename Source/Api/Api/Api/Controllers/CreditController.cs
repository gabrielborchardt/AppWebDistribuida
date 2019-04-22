using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("credit")]
    [ApiController]
    public class CreditController : ControllerBase
    {
        private readonly ICreditService _service;

        public CreditController(ICreditService service)
        {
            _service = service;
        }

        [Route("consult")]
        public IActionResult Consult([FromBody]Models.Parameter.Request.CreditConsult parameters)
        {
            try
            {
                return Ok(_service.Consult(parameters));
            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}