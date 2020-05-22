using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LSWebApiDapperMySql.Domain.Entity
{
    public class Produto
    {
        public int Codigo { get; set; }
        public string Nome { get; set; }
        public string Marca { get; set; }
        public double Preco { get; set; }
    }
}
