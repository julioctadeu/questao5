using MediatR;
using Questao5.Domain.Entities;

namespace Questao5.Application.Queries
{
    public class GetSaldoByIdQuery : IRequest<Movimento>
    {
        public string Id {get; set;}
    }
}