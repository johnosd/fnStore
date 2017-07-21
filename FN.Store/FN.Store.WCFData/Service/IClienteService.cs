using FN.Store.WCFData.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace FN.Store.WCFData.Service
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IClienteService" in both code and config file together.
    [ServiceContract]
    public interface IClienteService
    {
        [OperationContract]
        [WebGet(UriTemplate="clientes", ResponseFormat=WebMessageFormat.Json)]
        IEnumerable<ClienteVM> ObterTodos();

        [OperationContract]
        [WebGet(UriTemplate="clientes/{id}", ResponseFormat=WebMessageFormat.Json)]
        ClienteVM ObterPorId(string id);
    }
}
