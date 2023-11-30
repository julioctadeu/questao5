using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Questao5.Domain.Entities
{
    public class IdEmpotencia
    {
        public string chave_idempotencia { get; set; }
        public string requisicao { get; set; }
        public string resultado { get; set; }
    }
}