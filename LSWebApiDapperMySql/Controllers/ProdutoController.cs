using LSWebApiDapperMySql.Domain;
using LSWebApiDapperMySql.Domain.Entity;
using LSWebApiDapperMySql.Domain.Repository;
using LSWebApiDapperMySql.Domain.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace LSWebApiDapperMySql.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        readonly IProdutoRepository produtoRepository;

        readonly IProdutoServices produtoService;

        public ProdutoController(IProdutoServices produtoService, IProdutoRepository produtoRepository)
        {
            this.produtoService = produtoService;
            this.produtoRepository = produtoRepository;
        }

        [HttpGet]
        [Route("ObterTodosProdutos")]
        public IActionResult ObterTodosProdutos()
        {
            try
            {
                var result = produtoRepository.GetAll();

                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest($"Erro {e.Message}");
            }
        }

        [HttpGet]
        [Route("ObterProdutosPorMarca")]
        public IActionResult ObterProdutosPorMarca(string marca)
        {
            try
            {
                var result = produtoRepository.GetByProdutosMarca(marca);

                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest($"Erro {e.Message}");
            }
        }

        [HttpGet]
        [Route("ObterProdutosPorNome")]
        public IActionResult ObterProdutosPorNome(string nome)
        {
            try
            {
                var result = produtoRepository.GetByProdutosNome(nome);

                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest($"Erro {e.Message}");
            }
        }

        [HttpPost]
        public IActionResult InserirProduto([FromBody] Produto produto)
        {
            try
            {
                var result = produtoService.Inserir(produto);

                if (result.TemErros)
                {
                    return new BadRequestObjectResult(result);
                }
                else
                {
                    return Created($"/api/produto/{produto.Codigo}", produto);
                }
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Erro {e.Message}");
            }
        }

        [HttpPut]
        public IActionResult AtualizarProduto([FromBody] Produto produto)
        {
            try
            {
                var result = produtoService.Atualizar(produto);

                if (result.TemErros)
                {
                    return new BadRequestObjectResult(result);
                }
                else
                {
                    return Accepted($"/api/produto/{produto.Codigo}", produto);
                }

            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Erro {e.Message}");
            }
        }

        //public IActionResult Result(Result result)
        //{
        //    if(result.TemErros)
        //    {
        //        return new BadRequestObjectResult(result);
        //    }

        //    return Ok();
        //}

        private static readonly string[] Marcas = new[]     {
            "Dell", "Aoc", "HP", "LG", "Samsung", "Motorola", "Renault", "GM", "Toyota", "Honda"
        };

        private static readonly string[] Produtos = new[]     {
            "Notebook Identity", "Mouse", "Monitor", "Teclado", "Logan", "Corola", "Gol", "Civic", "Impressoras", "Copo", "Saveiro"
        };
    }
}
