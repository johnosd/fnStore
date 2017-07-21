using FN.Store.Data.EF;
using FN.Store.Data.EF.Repository;
using FN.Store.Domain.Entities;
using FN.Store.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FN.Store.UI.Web.Controllers
{
    public class ClientesController : Controller
    {
        //
        // GET: /Clientes/

        //private readonly StoreDataContext contexto = new StoreDataContext();
        private readonly IClienteRepository _clienteRepo =
            new ClienteRepository();

        public ActionResult Index()
        {
            //var clientes = contexto.Clientes.ToList();
            var clientes = _clienteRepo.Obter();
            return View(clientes);
        }

        public ActionResult Novo()
        {
            return View("AddEdit", new Cliente());
        }

        public ActionResult Editar(int id)
        {
            //var cliente = contexto.Clientes.Find(id);
            var cliente = _clienteRepo.Obter(id);
            if (cliente == null)
            {
                return HttpNotFound();
            }

            return View("AddEdit", cliente);
        }

        public ActionResult Salvar(Cliente cli)
        {
            if (ModelState.IsValid)
            {
                if (cli.Id == 0)
                {
                    //contexto.Clientes.Add(cli);
                    _clienteRepo.Adicionar(cli);
                }
                else
                {
                    //contexto.Entry(cli).State = System.Data.Entity.EntityState.Modified;
                    _clienteRepo.Editar(cli);
                }


                //contexto.SaveChanges();
            }
            else
            {
                return View("Novo");
            }

            return RedirectToAction("Index");
        }


        public JsonResult Excluir(int id)
        {
            var sucesso = true;
            var mensagem = "excluído c/ sucesso";

            //var cli = contexto.Clientes.Find(id);
            var cli = _clienteRepo.Obter(id);

            if (cli == null)
            {
                sucesso = false;
                mensagem = "cliente não existe";
            }
            else
            {
                //contexto.Clientes.Remove(cli);
                //contexto.SaveChanges();
                _clienteRepo.Excluir(cli);
            }

            return Json(new { sucesso = sucesso, mensagem = mensagem });
        }


        protected override void Dispose(bool disposing)
        {
            //contexto.Dispose();
            _clienteRepo.Dispose();
        }

    }
}
