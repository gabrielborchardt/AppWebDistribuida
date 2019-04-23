using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiFake.Repositories
{
    public interface ICreditRepository
    {
        int GetCountExpiredCredit(string cpf);
    }
}
