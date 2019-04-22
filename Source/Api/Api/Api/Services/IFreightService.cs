using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Services
{
    public interface IFreightService
    {
        Models.Parameter.Response.FreightConsult Consult(Models.Parameter.Request.FreightConsult parameters);
    }
}
