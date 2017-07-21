using FN.Store.Domain.Entities;
using FN.Store.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FN.Store.Data.EF.Repository
{
    public class ProdutoRepository:Repository<Produto>, IProdutoRepository
    {
    }
}
