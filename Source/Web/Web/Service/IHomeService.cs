using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.Parameter.Response;

namespace Web.Service
{
    public interface IHomeService
    {
        CreditConsult CreditConsult(string cpf, string token);
        FreightConsult FreightConsult(string cep, decimal tamanho, decimal peso, string token);
    }
}
