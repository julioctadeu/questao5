using Dapper;
using Questao5.Domain.Entities;

namespace Questao5.Infrastructure.Database.QueryStore
{
    public class QueryRepository : DapperContext, IQueryRepository
    {
        public QueryRepository(IConfiguration configuration): base(configuration)
        {  
        }

        
        public async Task<ContaCorrente> GetContaCorrenteById(string idConta)
        {
            using (var db = CreateConnection())
            {
                string sqlQuery = String.Format(
                    "SELECT ativo FROM contacorrente WHERE idcontacorrente = {0}",
                    idConta
                );

                var result = await db.QuerySingleOrDefaultAsync<ContaCorrente>(sqlQuery);

                return result;
            }
        }
    }
}