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

            ret.PossuiDividasEmpresa = !_repository.HaveExpiredCredit(parameters.Cpf) ? false : true;
            ret.PossuiDividasSerasa = !_serasaService.HaveExpiredCredit(parameters.Cpf) ? false : true;
            ret.ValorDisponivel = !ret.PossuiDividasEmpresa && !ret.PossuiDividasSerasa ? (decimal)Math.Round(new Random().Next(10, 100) * 325f, 2) : 0;

            return ret;
        }
    }
}
<<<<<<< HEAD

=======
>>>>>>> d4cb566e4d0f68e5ddfc56045f82867908bc6b3b
