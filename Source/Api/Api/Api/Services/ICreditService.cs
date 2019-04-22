using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Services
{
    public interface ICreditService
    {
        Models.Parameter.Response.CreditConsult Consult(Models.Parameter.Request.CreditConsult parameters);
    }
}
