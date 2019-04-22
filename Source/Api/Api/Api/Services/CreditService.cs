using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Repositories;
using Models.Parameter.Request;
using Models.Parameter.Response;

namespace Api.Services
{
    public class CreditService : ICreditService
    {
        private readonly ICreditRepository _repository;
        private readonly ISerasaService _serasaService;

        public CreditService(ICreditRepository repository, ISerasaService serasaService)
        {
            _repository = repository;
            _serasaService = serasaService;
        }

        public Models.Parameter.Response.CreditConsult Consult(Models.Parameter.Request.CreditConsult parameters)
        {
            var ret = new Models.Parameter.Response.CreditConsult();

            if (_repository.HaveExpiredCredit(parameters.Cpf))
            {
                ret.Liberado = true;

                if (_serasaService.HaveExpiredCredit(parameters.Cpf))
                    ret.Valor = (decimal)Math.Round(new Random().Next(10, 100) * 325f, 2);
                else
                    ret.Valor = 0;
            }
            else
            {
                ret.Liberado = false;
                ret.Valor = 0;
            }

            return ret;
        }
    }
}
}
