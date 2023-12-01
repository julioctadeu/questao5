using Questao5.Domain.Entities;

namespace Questao5.Infrastructure.Database.QueryStore
{
    public interface IQueryRepository
    {
        Task<ContaCorrente> GetContaCorrenteById(string idConta);
    }
}