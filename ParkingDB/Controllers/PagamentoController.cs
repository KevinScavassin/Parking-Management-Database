using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ParkingDB.Data;
using ParkingDB.Entities;
using ParkingDB.ViewModels;

[ApiController]
[Route("api/[controller]")]
public class PagamentoController : ControllerBase
{
    private readonly ParkingDBContext _context;

    public PagamentoController(ParkingDBContext context)
    {
        _context = context;
    }

    [HttpPost]
    public async Task<ActionResult<PagamentoResponseViewModel>> Post([FromBody] PagamentoRequestViewModel pagamentoRequest)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var metodoPagamentoExistente = await _context.MetodoPagamentos.FindAsync(pagamentoRequest.MetodoPagamentoId);
        if (metodoPagamentoExistente == null)
        {
            return BadRequest("Método de pagamento inválido.");
        }

        var pagamento = new Pagamento
        {
            Valor = pagamentoRequest.Valor,
            MetodoPagamento = metodoPagamentoExistente,
            DataHoraInclusao = DateTime.Now,
            UsuarioInclusao = "System",
            DataHoraAlteracao = DateTime.Now,
            UsuarioAlteracao = "System",
            IsActive = true
        };

        _context.Pagamentos.Add(pagamento);
        await _context.SaveChangesAsync();

        var response = new PagamentoResponseViewModel
        {
            Id = pagamento.Id,
            Valor = pagamento.Valor,
            MetodoPagamentoDescricao = metodoPagamentoExistente.Descricao
        };

        return CreatedAtAction(nameof(GetById), new { id = pagamento.Id }, response);
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<PagamentoResponseViewModel>>> Get()
    {
        var pagamentos = await _context.Pagamentos
            .Include(p => p.MetodoPagamento)
            .Select(p => new PagamentoResponseViewModel
            {
                Id = p.Id,
                Valor = p.Valor,
                MetodoPagamentoDescricao = p.MetodoPagamento.Descricao
            })
            .ToListAsync();

        return Ok(pagamentos);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<PagamentoResponseViewModel>> GetById(int id)
    {
        var pagamento = await _context.Pagamentos
            .Include(p => p.MetodoPagamento)
            .Where(p => p.Id == id)
            .Select(p => new PagamentoResponseViewModel
            {
                Id = p.Id,
                Valor = p.Valor,
                MetodoPagamentoDescricao = p.MetodoPagamento.Descricao
            })
            .FirstOrDefaultAsync();

        if (pagamento == null)
        {
            return NotFound("Pagamento não encontrado.");
        }

        return Ok(pagamento);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, [FromBody] PagamentoRequestViewModel pagamentoRequest)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var pagamento = await _context.Pagamentos.Include(p => p.MetodoPagamento).FirstOrDefaultAsync(p => p.Id == id);
        if (pagamento == null)
        {
            return NotFound("Pagamento não encontrado.");
        }

        var metodoPagamentoExistente = await _context.MetodoPagamentos.FindAsync(pagamentoRequest.MetodoPagamentoId);
        if (metodoPagamentoExistente == null)
        {
            return BadRequest("Método de pagamento inválido.");
        }

        pagamento.Valor = pagamentoRequest.Valor;
        pagamento.MetodoPagamento = metodoPagamentoExistente;
        pagamento.DataHoraAlteracao = DateTime.Now;
        pagamento.UsuarioAlteracao = "System";

        _context.Pagamentos.Update(pagamento);
        await _context.SaveChangesAsync();

        var response = new PagamentoResponseViewModel
        {
            Id = pagamento.Id,
            Valor = pagamento.Valor,
            MetodoPagamentoDescricao = pagamento.MetodoPagamento.Descricao
        };

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var pagamento = await _context.Pagamentos.FindAsync(id);
        if (pagamento == null)
        {
            return NotFound("Pagamento não encontrado.");
        }

        _context.Pagamentos.Remove(pagamento);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}
