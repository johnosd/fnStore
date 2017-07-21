using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FN.Store.Domain.Entities
{
    public class Cliente : EntidadeBase
    {
        public Cliente()
        {
            Telefones = new List<Telefone>();
        }

        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        
        public Sexo Sexo { get; set; }

        public virtual ICollection<Telefone> Telefones { get; set; }

    }

    public enum Sexo:byte { Masculino = 1,Feminino=0}

}
