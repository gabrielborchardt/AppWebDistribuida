using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace Api.Services
{
    public class SerasaService : ISerasaService
    {
        private readonly string _apiSerasa;

        public SerasaService(IConfiguration configuration)
        {
            _apiSerasa = configuration["SerasaApi"];
        }

        public bool HaveExpiredCredit(string cpf)
        {
            using (var api = new HttpClient { BaseAddress = new Uri(_apiSerasa) })
            {
                var apiResult = api.GetAsync($"credit/consult?cpf={cpf}").Result;

                switch (apiResult.StatusCode)
                {
                    case HttpStatusCode.OK:
                        return Convert.ToBoolean(apiResult.Content.ReadAsStringAsync().Result);
                    default:
                        throw new Exception("Erro ao buscar CPF na Api Serasa: " + apiResult.Content.ReadAsStringAsync().Result);
                }

            }
        }
    }
}
