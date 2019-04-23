using ApiFake.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiFake.Services
{
    public class CreditService : ICreditService
    {
        private readonly ICreditRepository _repository;

        public CreditService(ICreditRepository repository)
        {
            _repository = repository;
        }

        public bool Consult(string cpf)
        {
            return _repository.GetCountExpiredCredit(cpf) > 0 ? true : false;
        }
    }
}
