using LSWebApiDapperMySql.Domain.Entity;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using System.Data;

namespace LSWebApiDapperMySql.Domain.Repository
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly MySqlConnection connection;
        private MySqlTransaction Transaction;

        public ProdutoRepository(MySqlConnection connection)
        {
            this.connection = connection;
        }

        public void Atualizar(Produto produto)
        {
            var query = "ATUALIZAR_PRODUTO";

            connection.Open();
            using (Transaction = connection.BeginTransaction())
            {
                try
                {
                    connection.Execute(query, new {_CODIGO = produto.Codigo, _NOME = produto.Nome, _MARCA = produto.Marca, _PRECO = produto.Preco }, commandType: CommandType.StoredProcedure, transaction: Transaction);
                    Transaction.Commit();
                }
                catch (Exception e)
                {
                    Transaction.Rollback();
                    throw e;
                }
                finally
                {
                    connection.Dispose();
                }
            }
        }

        public void Excluir(Produto produto)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Produto> GetAll()
        {
            var query = "OBTER_PRODUTOS";

            return connection.Query<Produto>(query, commandType: CommandType.StoredProcedure);
        }

        public IEnumerable<Produto> GetByProdutosMarca(string marca)
        {
            var query = "OBTER_PRODUTOS_POR_MARCA";

            return connection.Query<Produto>(query, new { MARCA = marca }, commandType: CommandType.StoredProcedure);
        }

        public IEnumerable<Produto> GetByProdutosNome(string nome)
        {
            var query = "OBTER_PRODUTOS_POR_NOME";

            return connection.Query<Produto>(query, new { NOME = nome }, commandType: CommandType.StoredProcedure);
        }

        public Produto GetByProdutosNomeCerto(string nome)
        {
            var query = "OBTER_PRODUTOS_POR_NOME_CERTO";

            return connection.QueryFirstOrDefault<Produto>(query, new { NOME = nome }, commandType: CommandType.StoredProcedure);
        }

        public void Inserir(Produto produto)
        {
            var query = "INSERIR_PRODUTO";

            connection.Open();
            using (Transaction = connection.BeginTransaction())
            {
                try
                {
                    connection.Execute(query, new { NOME = produto.Nome, MARCA = produto.Marca, PRECO = produto.Preco }, commandType: CommandType.StoredProcedure, transaction: Transaction);
                    Transaction.Commit();
                }
                catch (Exception e)
                {
                    Transaction.Rollback();
                    throw e;
                }
                finally
                {
                    connection.Dispose();
                }
            }
        }
    }
}
