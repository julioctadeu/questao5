using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Questao5.Domain.Entities
{
    public class Movimento
    {
        public string IdMovimento { get; set; }
        public string IdContacorrente { get; set; }
        public string DataMovimento { get; set; }
        public string TipoMovimento { get; set; }
    }
}