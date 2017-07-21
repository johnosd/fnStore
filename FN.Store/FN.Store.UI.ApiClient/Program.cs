using FN.Store.Domain.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace FN.Store.UI.ApiClient
{
    class Program
    {
        static void Main(string[] args)
        {

            using (var client = new HttpClient())
            {
                var response = client.GetAsync("http://localhost:14369/api/clientes").Result;
                if (response.IsSuccessStatusCode)
                {
                    var clientes = JsonConvert.DeserializeObject<IEnumerable<Cliente>>(response.Content.ReadAsStringAsync().Result);
                    clientes.ToList().ForEach(cli=> {
                        Console.WriteLine("id:{0} - Nome:{1}",cli.Id, cli.Nome);
                    });
                }
                else
                {
                    Console.WriteLine("Erro ao obter os clientes");
                }
                Console.ReadLine();
            }
        }
    }
}
