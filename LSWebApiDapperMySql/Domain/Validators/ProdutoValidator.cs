using FluentValidation;
using LSWebApiDapperMySql.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LSWebApiDapperMySql.Domain.Validators
{
    public class ProdutoValidator : AbstractValidator<Produto>
    {
        public void ValidarNome() => RuleFor(x => x.Nome).NotEmpty().WithMessage("Nome obrigatório").MaximumLength(200).WithMessage("Tamanho máximo para o nome é 200 caracteres");
        public void ValidarMarca() => RuleFor(x => x.Marca).NotEmpty().WithMessage("Marca obrigatória").MaximumLength(200).WithMessage("Tamanho máximo para a marca é 200 caracteres");
        public void ValidarPreco() => RuleFor(x => x.Preco).NotEmpty().WithMessage("Preço obrigatório").GreaterThan(0).WithMessage("Preço tem que ser maior que zero (0)");
    }
}
