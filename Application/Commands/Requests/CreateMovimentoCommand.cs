using MediatR;
using Questao5.Application.Commands.Responses;
using Questao5.Domain.Entities;

namespace Questao5.Application.Commands
{
    public class CreateMovimentoCommand : IRequest<MovimentoResponse>
    {
        public CreateMovimentoCommand(
            string idConta,
            string data, 
            string tipo,
            decimal valor)
        {
            IdContacorrente = idConta;
            DataMovimento = data;
            TipoMovimento = tipo;
            Valor = valor;
        }
        public string IdContacorrente { get; set; }
        public string DataMovimento { get; set; }
        public string TipoMovimento { get; set; }
        public decimal Valor {get; set;}
    }
}