using FN.Store.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FN.Store.Domain.Repositories
{
    public interface IRepository<T> : IDisposable
        where T : EntidadeBase
    {
        T Obter(int id);
        IEnumerable<T> Obter();

        T Adicionar(T obj);
        T Editar(T obj);
        void Excluir(T obj);

    }
}
