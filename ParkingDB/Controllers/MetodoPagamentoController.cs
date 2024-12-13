using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ParkingDB.Data;
using ParkingDB.Entities;
using ParkingDB.ViewModels;

[ApiController]
[Route("api/[controller]")]
public class MetodoPagamentoController : ControllerBase
{
    private readonly ParkingDBContext _context;

    public MetodoPagamentoController(ParkingDBContext context)
    {
        _context = context;
    }

    [HttpPost]
    public async Task<ActionResult<MetodoPagamentoResponseViewModel>> Post([FromBody] MetodoPagamentoRequestViewModel metodoPagamentoRequest)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var metodoPagamento = new MetodoPagamento
        {
            Descricao = metodoPagamentoRequest.Descricao,
            DataHoraInclusao = DateTime.Now,
            UsuarioInclusao = "System",
            DataHoraAlteracao = DateTime.Now,
            UsuarioAlteracao = "System",
            IsActive = true
        };

        _context.MetodoPagamentos.Add(metodoPagamento);
        await _context.SaveChangesAsync();

        var response = new MetodoPagamentoResponseViewModel
        {
            Id = metodoPagamento.Id,
            Descricao = metodoPagamento.Descricao
        };

        return CreatedAtAction(nameof(GetById), new { id = metodoPagamento.Id }, response);
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<MetodoPagamentoResponseViewModel>>> Get()
    {
        var metodosPagamento = await _context.MetodoPagamentos
            .Select(m => new MetodoPagamentoResponseViewModel
            {
                Id = m.Id,
                Descricao = m.Descricao
            })
            .ToListAsync();

        return Ok(metodosPagamento);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<MetodoPagamentoResponseViewModel>> GetById(int id)
    {
        var metodoPagamento = await _context.MetodoPagamentos
            .Where(m => m.Id == id)
            .Select(m => new MetodoPagamentoResponseViewModel
            {
                Id = m.Id,
                Descricao = m.Descricao
            })
            .FirstOrDefaultAsync();

        if (metodoPagamento == null)
        {
            return NotFound("Método de pagamento não encontrado.");
        }

        return Ok(metodoPagamento);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, [FromBody] MetodoPagamentoRequestViewModel metodoPagamentoRequest)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var metodoPagamento = await _context.MetodoPagamentos.FirstOrDefaultAsync(m => m.Id == id);
        if (metodoPagamento == null)
        {
            return NotFound("Método de pagamento não encontrado.");
        }

        metodoPagamento.Descricao = metodoPagamentoRequest.Descricao;
        metodoPagamento.DataHoraAlteracao = DateTime.Now;
        metodoPagamento.UsuarioAlteracao = "System";

        _context.MetodoPagamentos.Update(metodoPagamento);
        await _context.SaveChangesAsync();

        var response = new MetodoPagamentoResponseViewModel
        {
            Id = metodoPagamento.Id,
            Descricao = metodoPagamento.Descricao
        };

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var metodoPagamento = await _context.MetodoPagamentos.FindAsync(id);
        if (metodoPagamento == null)
        {
            return NotFound("Método de pagamento não encontrado.");
        }

        _context.MetodoPagamentos.Remove(metodoPagamento);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}
