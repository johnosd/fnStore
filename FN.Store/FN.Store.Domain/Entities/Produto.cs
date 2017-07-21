using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FN.Store.Domain.Entities
{
    public class Produto:EntidadeBase
    {
        public string Nome { get; set; }
        public decimal Preco { get; set; }
    }
}
