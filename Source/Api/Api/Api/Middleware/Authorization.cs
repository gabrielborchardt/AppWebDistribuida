using Api.Repositories;
using Api.Services;
using Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Api.Middleware
{
    public class Authorization
    {
        private readonly RequestDelegate _next;
        private readonly IAuthenticationService _service;

        public Authorization(RequestDelegate next, IConfiguration configuration)
        {
            _next = next;
            _service = new AuthenticationService(new AuthenticationRepository(configuration));
        }

        public async Task Invoke(HttpContext context)
        {
            var route = context.Request.Path.Value;

            if (!route.Equals("/authentication") && !route.Equals("/") && !route.Equals("/favicon.ico"))
            {
                var token = context.Request.Headers["Authorization"];

                var userCode = MD5Helper.Uncrypt(token);

                if (!_service.IsAuth(userCode, route))
                {
                    var response = context.Response;
                    response.ContentType = "text/plain; charset=utf-8";
                    response.StatusCode = 401;

                    await response.WriteAsync("Usuário não possui acesso.");

                }
                else
                    await _next(context);
            }
            else
                await _next(context);
        }

    }
}
