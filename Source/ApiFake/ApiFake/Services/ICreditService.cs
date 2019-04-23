using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiFake.Services
{
    public interface ICreditService
    {
        bool Consult(string cpf);
    }
}
