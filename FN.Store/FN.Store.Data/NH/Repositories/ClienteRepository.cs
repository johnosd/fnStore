using FN.Store.Domain.Entities;
using FN.Store.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FN.Store.Data.NH.Repositories
{
    public class ClienteRepository:IClienteRepository
    {
        public Domain.Entities.Cliente ObterPorNome(string nome)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Domain.Entities.Cliente> ObterClientesComTelefones()
        {
            return new List<Cliente>() { 
                new Cliente{Nome="NHibernate", Sexo=Sexo.Feminino}
            };
        }

        public IQueryable<Domain.Entities.Cliente> ObterOData()
        {
            throw new NotImplementedException();
        }

        public Domain.Entities.Cliente Obter(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Domain.Entities.Cliente> Obter()
        {
            throw new NotImplementedException();
        }

        public Domain.Entities.Cliente Adicionar(Domain.Entities.Cliente obj)
        {
            throw new NotImplementedException();
        }

        public Domain.Entities.Cliente Editar(Domain.Entities.Cliente obj)
        {
            throw new NotImplementedException();
        }

        public void Excluir(Domain.Entities.Cliente obj)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            return;
        }
    }
}
