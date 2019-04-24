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

        [HttpGet]
        [Route("consult")]
        public IActionResult Consult(string cpf)
        {
            var parameters = new Models.Parameter.Request.CreditConsult();
            parameters.Cpf = cpf;

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