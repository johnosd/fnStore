using Microsoft.ServiceBus.Messaging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FN.Store.SB.Client
{
    class Program
    {
        static void Main(string[] args)
        {

            //string de conexão com o service bus
            var conn = @"Endpoint=sb://fnstorej.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=ZXUvhikTvK0Vecog6igJSAJhzKYKKIXj/Lcz6H3YRHE=";

            //fila criada dentro do service bus
            var queue = "produtos";

            var server = QueueClient.CreateFromConnectionString(conn, queue);
            server.OnMessage(msg=> {
                Console.WriteLine("id:{0}",msg.MessageId);
                var produtos = JsonConvert.DeserializeObject<List<ProdutoVM>>(msg.GetBody<string>());
                foreach (var prod in produtos)
                {
                    Console.WriteLine("Produtos: {0}",prod.Nome);
                }
                
                });
        }
    }
    class ProdutoVM
    {
        public string Nome { get; set; }
        public decimal Preco { get; set; }

    }
}
