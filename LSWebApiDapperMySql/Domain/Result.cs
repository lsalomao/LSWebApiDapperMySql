using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LSWebApiDapperMySql.Domain
{
    public class Result
    {
        List<string> _erros;
        public List<string> Erros => _erros;
        public bool TemErros => _erros.Any();

        public Result() => _erros = new List<string>();

        public void AddError(string error) => _erros.Add(error);

        public void AddErros(IEnumerable<string> erros) => _erros.AddRange(erros);
    }
}
