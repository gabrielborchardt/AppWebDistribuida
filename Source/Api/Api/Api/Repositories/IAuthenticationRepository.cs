using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Repositories
{
    public interface IAuthenticationRepository
    {
        bool UserIsValid(string user);
        bool CredentialsIsValid(string user, string pass);
        bool IsAuth(string userCode, string route);
        int GetUserCode(string user, string pass);
    }
}
