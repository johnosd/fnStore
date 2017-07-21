using FN.Store.Domain.Entities;
using FN.Store.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity; //é para dar o include c/ intelisensse

namespace FN.Store.Data.EF.Repository
{
    public class ClienteRepository:Repository<Cliente>, IClienteRepository
    {
        public Cliente ObterPorNome(string nome)
        {
            return contexto.Clientes.FirstOrDefault(c=>c.Nome.Contains(nome));
        }


        public IEnumerable<Cliente> ObterClientesComTelefones()
        {
            return contexto.Clientes
                .Include(x=>x.Telefones)
                .ToList();
        }


        public IQueryable<Cliente> ObterOData()
        {
            return contexto.Clientes;
        }
    }
}
