using FN.Store.Data.EF.Repository;
using Microsoft.ServiceBus.Messaging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FN.Store.SB.Service
{
    class Program
    {
        static void Main(string[] args)
        {
            IEnumerable<ProdutoVM> produtos;
            using (var repo = new ProdutoRepository())
            {
                produtos = repo.Obter().Select(p => new ProdutoVM { Nome = p.Nome, Preco = p.Preco });
            }

            //string de conexão com o service bus
            var conn = @"Endpoint=sb://fnstorej.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=ZXUvhikTvK0Vecog6igJSAJhzKYKKIXj/Lcz6H3YRHE=";

            //fila criada dentro do service bus
            var queue = "produtos";

            var server = QueueClient.CreateFromConnectionString(conn, queue);

            var message = JsonConvert.SerializeObject(produtos);

            server.Send(new BrokeredMessage(message));
            Console.WriteLine();
        }
    }

    class ProdutoVM
    {
        public string Nome { get; set; }
        public decimal Preco { get; set; }

    }

}
