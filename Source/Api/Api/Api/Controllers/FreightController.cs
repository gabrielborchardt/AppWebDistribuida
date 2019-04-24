using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.Parameter.Request;

namespace Api.Controllers
{
    [Route("freight")]
    [ApiController]
    public class FreightController : ControllerBase
    {
        private readonly IFreightService _service;

        public FreightController(IFreightService service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("consult")]
        public IActionResult Consult(string cep, decimal tamanho, decimal peso)
        {
            var parameters = new FreightConsult();
            parameters.CepDestino = cep;
            parameters.Tamanho = tamanho;
            parameters.Peso = peso;

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