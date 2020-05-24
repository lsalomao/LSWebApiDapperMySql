using LSWebApiDapperMySql.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LSWebApiDapperMySql.Domain.Services
{
    public interface IProdutoServices
    {
        Result Inserir(Produto produto);

        Result Atualizar(Produto produto);
        bool IsValid(Produto produto);
    }
}
