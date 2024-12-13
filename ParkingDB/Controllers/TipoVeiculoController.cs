using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ParkingDB.Data;
using ParkingDB.Entities;
using ParkingDB.ViewModels;

[ApiController]
[Route("api/[controller]")]
public class TipoVeiculoController : ControllerBase
{
    private readonly ParkingDBContext _context;

    public TipoVeiculoController(ParkingDBContext context)
    {
        _context = context;
    }

    [HttpPost]
    public async Task<ActionResult<TipoVeiculoResponseViewModel>> Post([FromBody] TipoVeiculoRequestViewModel tipoVeiculoRequest)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var tipoVeiculo = new TipoVeiculo
        {
            Descricao = tipoVeiculoRequest.Descricao,
            DataHoraInclusao = DateTime.Now,
            UsuarioInclusao = "System",
            DataHoraAlteracao = DateTime.Now,
            UsuarioAlteracao = "System",
            IsActive = true
        };

        _context.TipoVeiculos.Add(tipoVeiculo);
        await _context.SaveChangesAsync();

        var response = new TipoVeiculoResponseViewModel
        {
            Id = tipoVeiculo.Id,
            Descricao = tipoVeiculo.Descricao
        };

        return CreatedAtAction(nameof(GetById), new { id = tipoVeiculo.Id }, response);
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<TipoVeiculoResponseViewModel>>> Get()
    {
        var tipoVeiculos = await _context.TipoVeiculos
            .Select(t => new TipoVeiculoResponseViewModel
            {
                Id = t.Id,
                Descricao = t.Descricao
            })
            .ToListAsync();

        return Ok(tipoVeiculos);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<TipoVeiculoResponseViewModel>> GetById(int id)
    {
        var tipoVeiculo = await _context.TipoVeiculos
            .Where(t => t.Id == id)
            .Select(t => new TipoVeiculoResponseViewModel
            {
                Id = t.Id,
                Descricao = t.Descricao
            })
            .FirstOrDefaultAsync();

        if (tipoVeiculo == null)
        {
            return NotFound("Tipo de veículo não encontrado.");
        }

        return Ok(tipoVeiculo);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, [FromBody] TipoVeiculoRequestViewModel tipoVeiculoRequest)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var tipoVeiculo = await _context.TipoVeiculos.FirstOrDefaultAsync(t => t.Id == id);
        if (tipoVeiculo == null)
        {
            return NotFound("Tipo de veículo não encontrado.");
        }

        tipoVeiculo.Descricao = tipoVeiculoRequest.Descricao;
        tipoVeiculo.DataHoraAlteracao = DateTime.Now;
        tipoVeiculo.UsuarioAlteracao = "System";

        _context.TipoVeiculos.Update(tipoVeiculo);
        await _context.SaveChangesAsync();

        var response = new TipoVeiculoResponseViewModel
        {
            Id = tipoVeiculo.Id,
            Descricao = tipoVeiculo.Descricao
        };

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var tipoVeiculo = await _context.TipoVeiculos.FindAsync(id);
        if (tipoVeiculo == null)
        {
            return NotFound("Tipo de veículo não encontrado.");
        }

        _context.TipoVeiculos.Remove(tipoVeiculo);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}
