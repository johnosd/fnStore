using FN.Store.Data.EF.Repository;
using FN.Store.Domain.Entities;
using FN.Store.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace FN.Store.Api.Controllers
{
    public class ClientesController : ApiController
    {
        private readonly IClienteRepository _clienteRepo;
        public ClientesController(IClienteRepository clienteRepo)
        {
            _clienteRepo = clienteRepo;
        }


        public IEnumerable<Cliente> Get()
        {
            return _clienteRepo.ObterClientesComTelefones();
        }


        public HttpResponseMessage Get(int id)
        {
            var cliente = _clienteRepo.Obter(id);
            if (cliente == null)
                return Request.CreateResponse(HttpStatusCode.NotFound);


            return Request.CreateResponse(HttpStatusCode.OK, cliente);

        }

        public HttpResponseMessage Post(Cliente cli)
        {
            _clienteRepo.Adicionar(cli);
            return Request.CreateResponse(HttpStatusCode.Created, cli);
        }

        public HttpResponseMessage Put(int id, Cliente cli)
        {
            if (id == 0) 
            {
                return 
                    Request.CreateResponse(HttpStatusCode.BadRequest, "Id na Url inválido");
            }

            cli.Id = id;
            _clienteRepo.Editar(cli);
            return Request.CreateResponse(HttpStatusCode.NoContent);
        }

        public HttpResponseMessage Delete(int id)
        {
            var cliente = _clienteRepo.Obter(id);
            if (cliente == null)
                return Request.CreateResponse(HttpStatusCode.NotFound);

            _clienteRepo.Excluir(cliente);
            return Request.CreateResponse(HttpStatusCode.NoContent);
        }




        protected override void Dispose(bool disposing)
        {
            _clienteRepo.Dispose();
            base.Dispose(disposing);
        }
    }
}