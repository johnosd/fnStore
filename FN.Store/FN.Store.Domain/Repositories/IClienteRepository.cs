using FN.Store.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FN.Store.Domain.Repositories
{
    public interface IClienteRepository:IRepository<Cliente>
    {
        Cliente ObterPorNome(string nome);
        IEnumerable<Cliente> ObterClientesComTelefones();
        IQueryable<Cliente> ObterOData();
    }
}
