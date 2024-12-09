using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using DesafioFinal.Data;
using DesafioFinal.DTOs;
using DesafioFinal.Models;
using System.Linq;
using DesafioFinal.Models.Enum;

namespace DesafioFinal.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProdutoController : Controller
    {
        private readonly AppDbContext _context;

        public ProdutoController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet("{id}")]
        public IActionResult GetProduto(int id)
        {
            var produto = _context.Produtos.Where(p => p.Id == id);
            return Ok(produto);
        }

        [HttpGet]
        public IActionResult GetProdutos([FromQuery] StatusProdutos? status = null)
        {
            IQueryable<Produto> query = _context.Produtos;

            if (status.HasValue)
            {
                if (status == StatusProdutos.EmEstoque)
                {
                    query = query.Where(p => p.QuantidadeEstoque > 0);
                }
                else if (status == StatusProdutos.Indisponivel)
                {
                    query = query.Where(p => p.QuantidadeEstoque <= 0);
                }
            }
            var produtos = query.ToList();

            return Ok(produtos);
        }



        [Authorize(Roles ="Funcionario,Gerente")]
        [HttpPut("{id}")]
        public IActionResult AtualizaProdutoEstoque(int id, [FromBody] AtualizaProdutoEstoque dto)
        {
            var produto = _context.Produtos.Find(id);
            if (produto == null) return NotFound("Produto não encontrado");

            produto.QuantidadeEstoque = dto.QuantidadeEstoque;
            produto.Status = produto.QuantidadeEstoque > 0 ? "EmEstoque" : "Indisponivel";
            _context.SaveChanges();
            return Ok(produto);
        }
        [Authorize(Roles = "Funcionario, Gerente")]
        [HttpPost]
        public IActionResult InserirProduto([FromBody] InserirProduto dto)
        {
            var produto = _context.Produtos.FirstOrDefault(p => p.Nome == dto.Nome);
            if (produto == null)
            {
                Produto produtoNovo = new()
                {
                    Nome = dto.Nome,
                    Descricao = dto.Descricao,
                    Preco = dto.Preco,
                    QuantidadeEstoque = dto.QuantidadeEstoque,
                    Status = dto.QuantidadeEstoque > 0 ? "EmEstoque" : "Indisponivel"
                };
                _context.Produtos.Add(produtoNovo);
                _context.SaveChanges();
                return Ok(produtoNovo);
            }
            else
            {
                return BadRequest($"Produto {produto.Nome} ja existe com o id: {produto.Id}");
            }

        }

        [Authorize(Roles = "Gerente")]
        [HttpDelete("{id}")]
        public IActionResult DeletarProduto(int id)
        {
            var produto = _context.Produtos.Find(id);
            if (produto == null) return NotFound("Produto não encontrado");

            _context.Produtos.Remove(produto);
            _context.SaveChanges();
            return Ok("Produto excluido");
        }
    }
}
