using FluentValidation.Results;
using LSWebApiDapperMySql.Domain.Entity;
using LSWebApiDapperMySql.Domain.Repository;
using LSWebApiDapperMySql.Domain.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LSWebApiDapperMySql.Domain.Services
{
    public class ProdutoServices : IProdutoServices
    {
        readonly IProdutoRepository produtoRepository;

        public ProdutoServices(IProdutoRepository produtoRepository)
        {
            this.produtoRepository = produtoRepository;
        }

        public ValidationResult ValidationResult { get; set; }

        public Result Atualizar(Produto produto)
        {
            var result = new Result();
            if (IsValid(produto))
            {
                var produtoBase = produtoRepository.GetByProdutosNomeCerto(produto.Nome);
                if (produtoBase != null)
                {
                    produto.Codigo = produtoBase.Codigo;
                    produtoRepository.Atualizar(produto);
                }
                else
                {
                    result.AddError("Produto não existe!");
                }
            }
            else
            {
                result.AddErros(GetErrors());
            }

            return result;
        }

        public Result Inserir(Produto produto)
        {
            var result = new Result();
            if (IsValid(produto))
            {
                if (produtoRepository.GetByProdutosNomeCerto(produto.Nome) == null)
                {
                    produtoRepository.Inserir(produto);
                }
                else
                {
                    result.AddError("Produto já existe!");
                }
            }
            else
            {
                result.AddErros(GetErrors());
            }

            return result;
        }

        public bool IsValid(Produto produto)
        {
            var validation = new ProdutoValidator();
            validation.ValidarMarca();
            validation.ValidarNome();
            validation.ValidarPreco();

            ValidationResult = validation.Validate(produto);

            return ValidationResult.IsValid;
        }

        private IEnumerable<string> GetErrors() => ValidationResult.Errors.Select(err => err.ErrorMessage);
    }
}
