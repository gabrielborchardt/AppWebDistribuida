using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiFake.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiFake.Controllers
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

        [HttpGet]
        [Route("consult")]
        public IActionResult Consult(string cpf)
        {
            try
            {
                return Ok(_service.Consult(cpf));
            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}