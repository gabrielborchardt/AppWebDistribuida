using Dapper;
using Microsoft.Extensions.Configuration;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiFake.Repositories
{
    public class CreditRepository : ICreditRepository
    {
        private readonly IConfiguration _configuration;
        private readonly string _connString;

        public CreditRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            _connString = _configuration["CS"];
        }

        public int GetCountExpiredCredit(string cpf)
        {
            string sql = $"SELECT COUNT(*) FROM PES_BLOQUEIO WHERE NUMCPF = '{cpf}' AND FLGBLOQUEADO = 'S'";

            using (var connection = new NpgsqlConnection(_connString))
            {
                return connection.QueryFirstOrDefault<int>(sql);
            }
        }
    }
}
