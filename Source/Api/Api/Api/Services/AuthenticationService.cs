using Api.Repositories;
using Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        public readonly IAuthenticationRepository _repository;

        public AuthenticationService(IAuthenticationRepository repository)
        {
            _repository = repository;
        }

        public bool IsAuth(string userCode, string route)
        {
            return _repository.IsAuth(userCode, route);
        }

        public string Login(string user, string pass)
        {
            if (!_repository.UserIsValid(user))
                throw new Exception("Usuário não reconhecido.");

            if (!_repository.CredentialsIsValid(user, pass))
                throw new Exception("Senha incorreta.");

            return MD5Helper.Crypt(_repository.GetUserCode(user, pass).ToString());

        }
    }
}
