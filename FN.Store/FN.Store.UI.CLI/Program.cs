using FN.Store.Data.EF;
using FN.Store.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FN.Store.UI.CLI
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Obtendo Clientes...");

            var contexto = new StoreDataContext();
            var clientes = contexto.Clientes.ToList();

            foreach (Cliente cli in clientes)
            {
                Console.WriteLine("Id: {0} | Nome: {1} \nTels: {2}",cli.Id,cli.Nome,
                    string.Join(" | ",cli.Telefones.Select(x=>x.Numero)) 
                    );
                //foreach (var tels in cli.Telefones)
                //{
                //    Console.Write(tels.Numero);
                //}
            }

            Console.WriteLine("Fim");
            Console.ReadLine();

        }
    }
}
