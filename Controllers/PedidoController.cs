using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using TesteProjetoLojaAPI.Data;
using TesteProjetoLojaAPI.Models;

[Route("api/[controller]")]
[ApiController]
public class PedidoController : ControllerBase
{
    private readonly AppDbContext _context;
    public PedidoController(AppDbContext context)
    {
        _context = context;
    }

    [HttpPost("NovoPedido")]
    public IActionResult NovoPedido([FromBody] Pedido pedidoModel)
    {
        try
        {
            // Obter o produto pelo ID
            var produto = _context.Produto.FirstOrDefault(p => p.Id == pedidoModel.ProdutoId);

            if (produto == null)
            {
                return NotFound("Produto não encontrado.");
            }

            // Verificar se há estoque suficiente
            if (produto.Quantidade < pedidoModel.Quantidade)
            {
                return BadRequest("Quantidade solicitada excede o estoque disponível.");
            }

            // Criar um novo pedido
            var novoPedido = new Pedido
            {
                ProdutoId = pedidoModel.ProdutoId,
                Quantidade = pedidoModel.Quantidade,
                UsuarioId = pedidoModel.UsuarioId,
                DataCompra = DateTime.Now
            };

            // Adicionar o pedido ao contexto e salvar mudanças
            _context.Pedido.Add(novoPedido);

            // Atualizar a quantidade disponível do produto
            produto.Quantidade -= pedidoModel.Quantidade;

            _context.SaveChanges();

            return Ok("Pedido realizado com sucesso.");
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Erro ao processar pedido: {ex.Message}");
        }
    }

    [HttpGet("TodasVendas")]
    public IActionResult TodasVendas()
    {
        try
        {
            // Consultar todas as vendas
            var vendas = _context.Pedido
                .Include(p => p.Produto) // Incluir os dados do produto relacionado
                .ToList();

            return Ok(vendas);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Erro ao buscar vendas: {ex.Message}");
        }
    }

    [HttpGet]
    public ActionResult<IEnumerable<Pedido>> GetPedidos()
    {
        return _context.Pedido.ToList();
    }
}
