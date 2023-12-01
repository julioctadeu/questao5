using Questao5.Application.Commands;
using Questao5.Domain.Entities;

namespace Questao5.Infrastructure.Database.CommandStore
{
    public interface ICommandRepository
    {
        Task<string> CreateMovimento(CreateMovimentoCommand movimentoDetails);

    }
}