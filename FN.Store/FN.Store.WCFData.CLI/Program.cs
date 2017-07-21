using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FN.Store.WCFData.CLI
{
    class Program
    {
        static void Main(string[] args)
        {

            
            using (var proxy = new Clientes.ClienteServiceClient())
            {
                var clientes = proxy.ObterTodos();
                foreach (var cli in clientes)
                {
                    Console.WriteLine("Id: {0} | Nome: {1} | Data: {2:dd/MM/yyyy HH:mm}", 
                        cli.Id, cli.Nome, cli.DataLog);
                } 
            }
            
            Console.ReadLine();

        }
    }
}
