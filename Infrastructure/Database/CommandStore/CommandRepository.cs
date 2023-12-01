using Dapper;
using Questao5.Application.Commands;
using Questao5.Domain.Entities;

namespace Questao5.Infrastructure.Database.CommandStore
{
    public class CommandRepository : DapperContext, ICommandRepository
    {

        public CommandRepository(IConfiguration configuration): base(configuration)
        {  
        }

        public async Task<string> CreateMovimento(CreateMovimentoCommand movimentoDetails)
        {
            using (var db = CreateConnection())
            {
                Guid idMovimento = Guid.NewGuid();
                string sqlCommand = String.Format(
                        "INSERT INTO movimento (idmovimento, idcontacorrente, datamovimento, tipomovimento, valor)"
                        + " VALUES ({0}, {1}, {2}, {3}, {4}, {5}) RETURNING idmovimento", 
                        idMovimento.ToString(), movimentoDetails.IdContacorrente, movimentoDetails.DataMovimento, 
                        movimentoDetails.TipoMovimento, movimentoDetails.Valor);
                
                var result = await db.ExecuteScalarAsync<string>(sqlCommand);

                return result;
            }
            
        }

    }
}