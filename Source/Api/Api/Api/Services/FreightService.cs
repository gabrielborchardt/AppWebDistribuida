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
        private readonly ICepService _cepService;

        public FreightService(IFreightRepository repository, ICepService cepService)
        {
            _repository = repository;
            _cepService = cepService;
        }

        public Models.Parameter.Response.FreightConsult Consult(Models.Parameter.Request.FreightConsult parameters)
        {
            var ret = new Models.Parameter.Response.FreightConsult();
            var address = _cepService.GetAddress(parameters.CepDestino);

            ret.Valor = Math.Round(((parameters.Peso * 5) * parameters.Tamanho) / 10, 2);
            ret.Cidade = address.cidade;
            ret.Estado = address.uf;
            ret.Rua = address.logradouro;

            return ret;
        }
    }
}
