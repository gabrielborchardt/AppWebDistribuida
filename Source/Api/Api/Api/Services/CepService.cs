using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Models;
using Newtonsoft.Json;

namespace Api.Services
{
    public class CepService : ICepService
    {
        private readonly string _apiCep;

        public CepService(IConfiguration configuration)
        {
            _apiCep = configuration["CepApi"];
        }

        public Address GetAddress(string cepDestino)
        {
            using (var api = new HttpClient { BaseAddress = new Uri(_apiCep) })
            {
                var apiResult = api.GetAsync($"cep/busca?cep={cepDestino}").Result;

                switch (apiResult.StatusCode)
                {
                    case HttpStatusCode.OK:
                        var json = apiResult.Content.ReadAsStringAsync().Result;
                        return JsonConvert.DeserializeObject<List<Address>>(json)[0];
                    default:
                        throw new Exception("Erro ao buscar CEP: " + apiResult.Content.ReadAsStringAsync().Result);
                }

            }
        }
    }
}
