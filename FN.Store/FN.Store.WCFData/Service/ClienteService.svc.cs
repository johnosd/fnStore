using FN.Store.Data.EF.Repository;
using FN.Store.Domain.Repositories;
using FN.Store.WCFData.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace FN.Store.WCFData.Service
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "ClienteService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select ClienteService.svc or ClienteService.svc.cs at the Solution Explorer and start debugging.
    public class ClienteService : IClienteService
    {
        private IClienteRepository _cliRepo = new ClienteRepository();
        public IEnumerable<ClienteVM> ObterTodos()
        {
            return _cliRepo.Obter().Select(c => new ClienteVM { Id=c.Id, Nome=c.Nome });
        }

        public ClienteVM ObterPorId(string id)
        {
            var cli = _cliRepo.Obter(int.Parse(id));
            return new ClienteVM { Id=cli.Id, Nome=cli.Nome };
        }
    }
}
