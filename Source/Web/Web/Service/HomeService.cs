using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using Models.Parameter.Response;
using Newtonsoft.Json;

namespace Web.Service
{
    public class HomeService : IHomeService
    {
        private readonly string _api;

        public HomeService()
        {
            _api = ConfigurationManager.AppSettings["Api"];
        }

        public CreditConsult CreditConsult(string cpf, string token)
        {
            using (var api = new HttpClient { BaseAddress = new Uri(_api) })
            {
                api.DefaultRequestHeaders.TryAddWithoutValidation("Authorization", token);
                api.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json");

                var apiResult = api.GetAsync($"credit/consult?cpf={cpf}").Result;

                switch (apiResult.StatusCode)
                {
                    case HttpStatusCode.OK:
                        var json = apiResult.Content.ReadAsStringAsync().Result;
                        return JsonConvert.DeserializeObject<CreditConsult>(json);
                    default:
                        throw new Exception("Erro ao consultar CPF: " + apiResult.Content.ReadAsStringAsync().Result);
                }

            }
        }

        public FreightConsult FreightConsult(string cep, decimal tamanho, decimal peso, string token)
        {
            using (var api = new HttpClient { BaseAddress = new Uri(_api) })
            {
                api.DefaultRequestHeaders.TryAddWithoutValidation("Authorization", token);
                api.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json");

                var apiResult = api.GetAsync($"freight/consult?cep={cep}&tamanho={tamanho.ToString().Replace(".", "").Replace(",", ".")}&peso={peso.ToString().Replace(".", "").Replace(",", ".")}").Result;

                switch (apiResult.StatusCode)
                {
                    case HttpStatusCode.OK:
                        var json = apiResult.Content.ReadAsStringAsync().Result;
                        return JsonConvert.DeserializeObject<FreightConsult>(json);
                    default:
                        throw new Exception("Erro ao consultar CPF: " + apiResult.Content.ReadAsStringAsync().Result);
                }

            }
        }
    }
}