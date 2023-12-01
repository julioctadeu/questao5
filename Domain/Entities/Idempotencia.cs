using System.ComponentModel.DataAnnotations;

namespace Questao5.Domain.Entities
{
    public class Idempotencia
    {
        public string ChaveIdempotencia { get; set; }
        
        [StringLength(1000)]
        public string Requisicao { get; set; }
        
        [StringLength(1000)]
        public string Resultado { get; set; }
    }
}