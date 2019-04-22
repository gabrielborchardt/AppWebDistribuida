using Dapper;
using Microsoft.Extensions.Configuration;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Repositories
{
    public class AuthenticationRepository : IAuthenticationRepository
    {
        private readonly IConfiguration _configuration;
        private readonly string _connString;

        public AuthenticationRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            _connString = _configuration["AuthenticationApi"];
        }

        public bool UserIsValid(string user)
        {
            string sql = $"SELECT COUNT(*) FROM USU_DADOS WHERE EMAIL = '{user}'";

            using (var connection = new NpgsqlConnection(_connString))
            {
                return connection.QueryFirstOrDefault<int>(sql) > 0 ? true : false;
            }
        }

        public bool CredentialsIsValid(string user, string pass)
        {
            string sql = $"SELECT COUNT(*) FROM USU_DADOS WHERE EMAIL = '{user}' AND SENHA = '{pass}'";

            using (var connection = new NpgsqlConnection(_connString))
            {
                return connection.QueryFirstOrDefault<int>(sql) > 0 ? true : false;
            }
        }

        public bool IsAuth(string userCode, string route)
        {
            string sql = $"SELECT COUNT(*) FROM USU_ACESSO WHERE CODUSUARIO = '{userCode}' AND ROTA = '{route}'";

            using (var connection = new NpgsqlConnection(_connString))
            {
                return connection.QueryFirstOrDefault<int>(sql) > 0 ? true : false;
            }
        }

        public int GetUserCode(string user, string pass)
        {
            string sql = $"SELECT CODUSUARIO FROM USU_DADOS WHERE EMAIL = '{user}' AND SENHA = '{pass}'";

            using (var connection = new NpgsqlConnection(_connString))
            {
                return connection.QueryFirstOrDefault<int>(sql);
            }
        }
    }
}
