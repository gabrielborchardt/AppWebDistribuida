using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;

namespace Web.Service
{
    public class LoginService : ILoginService
    {
        private readonly string _api;

        public LoginService()
        {
            _api = ConfigurationManager.AppSettings["Api"];
        }

        public HttpResponseMessage Login(string email, string senha)
        {
            byte[] byt = System.Text.Encoding.UTF8.GetBytes($"{email}:{senha}");
            var base64 = Convert.ToBase64String(byt);

            using (var api = new HttpClient { BaseAddress = new Uri(_api) })
            {
                api.DefaultRequestHeaders.TryAddWithoutValidation("Authorization", $"Basic {base64}");
                api.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json");

                return api.PostAsync($"authentication", null).Result;
            }
        }
    }
}