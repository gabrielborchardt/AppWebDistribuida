using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Api.Repositories;
using Microsoft.Extensions.Configuration;
using Models;
using Models.Parameter.Request;
using Models.Parameter.Response;
using Newtonsoft.Json;

namespace Api.Services
{
    public class FreightService : IFreightService
    {
        private readonly IFreightRepository _repository;
        private readonly string _apiCep;

        public FreightService(IFreightRepository repository, IConfiguration configuration)
        {
            _repository = repository;
            _apiCep = _apiCep = configuration["CepApi"];
        }

        public Models.Parameter.Response.FreightConsult Consult(Models.Parameter.Request.FreightConsult parameters)
        {
            var ret = new Models.Parameter.Response.FreightConsult();
            var address = new Address();

            ret.Valor = Math.Round(((parameters.Peso * 5) * parameters.Tamanho) / 10, 2);

            using (var api = new HttpClient { BaseAddress = new Uri(_apiCep) })
            {
                var apiResult = api.GetAsync($"cep/busca?cep={parameters.CepDestino}").Result;

                switch (apiResult.StatusCode)
                {
                    case HttpStatusCode.OK:
                        var json = apiResult.Content.ReadAsStringAsync().Result;
                        address = JsonConvert.DeserializeObject<List<Address>>(json)[0];
                        break;
                    default:
                        throw new Exception("Erro ao buscar CEP: " + apiResult.Content.ReadAsStringAsync().Result);
                }

            }

            ret.Cidade = address.cidade;
            ret.Estado = address.uf;
            ret.Rua = address.logradouro;

            return ret;
        }
    }
}
