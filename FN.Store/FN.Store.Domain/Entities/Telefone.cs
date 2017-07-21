using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FN.Store.Domain.Entities
{
    public class Telefone : EntidadeBase
    {
        public string Numero { get; set; }

        public int ClienteId { get; set; }

        public virtual Cliente Cliente { get; set; }

    }
}
