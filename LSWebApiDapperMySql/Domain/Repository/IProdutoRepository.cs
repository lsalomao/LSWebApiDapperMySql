using LSWebApiDapperMySql.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LSWebApiDapperMySql.Domain.Repository
{
  public  interface IProdutoRepository
    {
        IEnumerable<Produto> GetAll();
        IEnumerable<Produto> GetByProdutosMarca(string marca);
        IEnumerable<Produto> GetByProdutosNome(string nome);
        void Inserir(Produto produto);
        void Atualizar(Produto produto);
        void Excluir(Produto produto);
        //bool SaveChange();
    }
}
