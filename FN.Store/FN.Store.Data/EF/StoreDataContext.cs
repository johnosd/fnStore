using FN.Store.Data.EF.Maps;
using FN.Store.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FN.Store.Data.EF
{
    public class StoreDataContext : DbContext
    {
        public StoreDataContext()
            : base("StoreDbConn")
        {
            Database.SetInitializer(new CargaInicial());
            Configuration.LazyLoadingEnabled = false; // desativar o lazyload (Eager Loading)
        }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Telefone> Telefones { get; set; }
        public DbSet<Produto> Produtos { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new ClienteMap());
            modelBuilder.Configurations.Add(new TelefoneMap());
            modelBuilder.Configurations.Add(new ProdutoMap());
        }

    }

    public class CargaInicial : CreateDatabaseIfNotExists<StoreDataContext>
    {

        protected override void Seed(StoreDataContext context)
        {
            var clientes = new List<Cliente>();
            clientes.Add(new Cliente()
            {
                Nome = "Fabiano",
                DataNascimento = new DateTime(1979, 9, 12),
                Sexo = Sexo.Masculino,
                Telefones = new List<Telefone>() {
            
                new Telefone(){ Numero="99123-4455"},
                new Telefone(){ Numero="98123-4455"},
                new Telefone(){ Numero="97123-4455"},
            
            }
            });

            var tels = new List<Telefone>();
            tels.Add(new Telefone() { Numero = "2244-3355" });
            clientes.Add(new Cliente() { Nome = "Priscila", Sexo = Sexo.Feminino, Telefones = tels, DataNascimento = new DateTime(1978, 6, 9) });

            clientes.Add(new Cliente() { Nome = "Raphael", Sexo = Sexo.Masculino, DataNascimento = new DateTime(1999, 8, 20) });

            context.Clientes.AddRange(clientes);

            context.Produtos.AddRange(

                new List<Produto> { 
                    new Produto{Nome="Geladeira CCE", Preco=150},
                    new Produto{Nome="Fogão Panasonic", Preco=15000},
                }
            );

            context.SaveChanges();

        }

    }

}
