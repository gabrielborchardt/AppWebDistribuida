using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Services;
using Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("authentication")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticationService _service;

        public AuthenticationController(IAuthenticationService service)
        {
            _service = service;
        }

        [HttpPost]
        public IActionResult Authentication()
        {
            try
            {
                var base64token = HttpContext.Request.Headers["Authorization"];
                var base64EncodedData = base64token.ToString().Substring(6);
                var loginPass = Base64Helper.Base64Decode(base64EncodedData);
                var credentials = loginPass.Split(':');

                var user = credentials[0];
                var pass = credentials[1];

                return Ok(_service.Login(user, pass));

            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}