using LSWebApiDapperMySql.Domain.Entity;
using LSWebApiDapperMySql.Domain.Repository;
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

        public ProdutoController(IProdutoRepository produtoRepository)
        {
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
                produtoRepository.Inserir(produto);

                //var rng = new Random();

                //for (int i = 0; i < 1000; i++)
                //{
                //    var produto1 = new Produto
                //    {
                //        Marca = Marcas[rng.Next(Marcas.Length)],
                //        //Nome = $" {Produtos[rng.Next(Produtos.Length)]} - {i * 5}",
                //        Preco = rng.Next(10, 5000)
                //    };

                //    produtoRepository.Inserir(produto1);
                //}

                return Created($"/api/produto/{produto.Codigo}", produto);

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
                produtoRepository.Atualizar(produto);


                return Accepted($"/api/produto/{produto.Codigo}", produto);

            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Erro {e.Message}");
            }
        }

        private static readonly string[] Marcas = new[]     {
            "Dell", "Aoc", "HP", "LG", "Samsung", "Motorola", "Renault", "GM", "Toyota", "Honda"
        };

        private static readonly string[] Produtos = new[]     {
            "Notebook Identity", "Mouse", "Monitor", "Teclado", "Logan", "Corola", "Gol", "Civic", "Impressoras", "Copo", "Saveiro"
        };
    }
}
