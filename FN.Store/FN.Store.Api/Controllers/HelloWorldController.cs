using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace FN.Store.Api.Controllers
{
    public class HelloWorldController:ApiController
    {
        public string Get()
        {
            return "HelloWorld";
        }

        public string Post(Teste teste)
        {
            return teste.Id + " - " + teste.Nome;
        }

        public void Put(int id, Teste teste)
        { 

        }

        public void Delete(int id)
        {

        }

    }

    public class Teste
    {
        public int Id { get; set; }
        public string Nome { get; set; }
    }

}