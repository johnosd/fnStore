using FN.Store.Domain.Entities;
using FN.Store.Domain.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace FN.Store.Data.EF.Repository
{
    public class Repository<T>:IRepository<T> where T:EntidadeBase
    {

        protected readonly StoreDataContext contexto = new StoreDataContext();

        public T Obter(int id)
        {
            return contexto.Set<T>().Find(id);
        }

        public IEnumerable<T> Obter()
        {
            return contexto.Set<T>().ToList();
        }

        public T Adicionar(T obj)
        {
            contexto.Set<T>().Add(obj);
            contexto.SaveChanges();
            return obj;
        }

        public T Editar(T obj)
        {
            contexto.Entry(obj).State = System.Data.Entity.EntityState.Modified;
            contexto.SaveChanges();
            return obj;
        }

        public void Excluir(T obj)
        {
            contexto.Set<T>().Remove(obj);
            contexto.SaveChanges();
        }

        public void Dispose()
        {
            contexto.Dispose();
        }
    }
}
