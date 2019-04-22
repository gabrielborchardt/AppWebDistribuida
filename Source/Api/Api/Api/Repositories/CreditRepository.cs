using Dapper;
using Microsoft.Extensions.Configuration;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Repositories
{
    public class CreditRepository : ICreditRepository
    {
        private readonly IConfiguration _configuration;
        private readonly string _connString;

        public CreditRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            _connString = _configuration["FinanceCS"];
        }

        public bool HaveExpiredCredit(string cpf)
        {
            string sql = $"SELECT COUNT(*) FROM FIN_RECEITA WHERE FLGPAGO = 'N' AND DATVENCIMENTO > CURRENT_DATE AND NUMCPF = '{cpf}'";

            using (var connection = new NpgsqlConnection(_connString))
            {
                return connection.QueryFirstOrDefault<int>(sql) > 0 ? true : false;
            }
        }
    }
}
