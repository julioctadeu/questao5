using Questao5.Domain.Entities;

namespace Questao5.Application.Commands.Responses
{
    public class MovimentoResponse : Movimento
    {
        public string IdMovimento { get; set; }
        public string IdContacorrente { get; set; }
        public string DataMovimento { get; set; }
        public string TipoMovimento { get; set; }
        public decimal Valor { get; set; }

        public MovimentoResponse()
        {
            
        }
        
        public MovimentoResponse(string idMovimento, string idConta,
                        string data, string tipo, decimal valor)
        {
            IdMovimento= idMovimento;
            IdContacorrente = idConta;
            DataMovimento = data;
            TipoMovimento = tipo;
            Valor = valor;
        }
    }
}