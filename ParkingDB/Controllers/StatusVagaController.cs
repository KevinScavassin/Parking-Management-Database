using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ParkingDB.Data;
using ParkingDB.Entities;
using ParkingDB.ViewModels;

[ApiController]
[Route("api/[controller]")]
public class StatusVagaController : ControllerBase
{
    private readonly ParkingDBContext _context;

    public StatusVagaController(ParkingDBContext context)
    {
        _context = context;
    }

    [HttpPost]
    public async Task<ActionResult<StatusVagaResponseViewModel>> Post([FromBody] StatusVagaRequestViewModel statusVagaRequest)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var statusVaga = new StatusVaga
        {
            Descricao = statusVagaRequest.Descricao,
            DataHoraInclusao = DateTime.Now,
            UsuarioInclusao = "System",
            DataHoraAlteracao = DateTime.Now,
            UsuarioAlteracao = "System",
            IsActive = true
        };

        _context.StatusVagas.Add(statusVaga);
        await _context.SaveChangesAsync();

        var response = new StatusVagaResponseViewModel
        {
            Id = statusVaga.Id,
            Descricao = statusVaga.Descricao
        };

        return CreatedAtAction(nameof(GetById), new { id = statusVaga.Id }, response);
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<StatusVagaResponseViewModel>>> Get()
    {
        var statusVagas = await _context.StatusVagas
            .Select(s => new StatusVagaResponseViewModel
            {
                Id = s.Id,
                Descricao = s.Descricao
            })
            .ToListAsync();

        return Ok(statusVagas);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<StatusVagaResponseViewModel>> GetById(int id)
    {
        var statusVaga = await _context.StatusVagas
            .Where(s => s.Id == id)
            .Select(s => new StatusVagaResponseViewModel
            {
                Id = s.Id,
                Descricao = s.Descricao
            })
            .FirstOrDefaultAsync();

        if (statusVaga == null)
        {
            return NotFound("Status de vaga não encontrado.");
        }

        return Ok(statusVaga);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, [FromBody] StatusVagaRequestViewModel statusVagaRequest)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var statusVaga = await _context.StatusVagas.FindAsync(id);
        if (statusVaga == null)
        {
            return NotFound("Status de vaga não encontrado.");
        }

        statusVaga.Descricao = statusVagaRequest.Descricao;
        statusVaga.DataHoraAlteracao = DateTime.Now;
        statusVaga.UsuarioAlteracao = "System";

        _context.StatusVagas.Update(statusVaga);
        await _context.SaveChangesAsync();

        var response = new StatusVagaResponseViewModel
        {
            Id = statusVaga.Id,
            Descricao = statusVaga.Descricao
        };

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var statusVaga = await _context.StatusVagas.FindAsync(id);
        if (statusVaga == null)
        {
            return NotFound("Status de vaga não encontrado.");
        }

        _context.StatusVagas.Remove(statusVaga);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}
