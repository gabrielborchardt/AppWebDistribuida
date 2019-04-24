using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Web.Service
{
    public interface ILoginService
    {
        HttpResponseMessage Login(string email, string senha);
    }
}
