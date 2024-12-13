using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ParkingDB.Data;
using ParkingDB.Entities;
using ParkingDB.ViewModels;

[Route("api/[controller]")]
[ApiController]
public class EstadosBrasileirosController : ControllerBase
{
    private readonly ParkingDBContext _context;

    public EstadosBrasileirosController(ParkingDBContext context)
    {
        _context = context;
    }

    [HttpPost]
    public async Task<ActionResult<EstadosBrasileirosResponseViewModel>> Post([FromBody] EstadosBrasileirosRequestViewModel estadoRequest)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var estado = new EstadosBrasileiros
        {
            UF = estadoRequest.UF,
            Nome = estadoRequest.Nome,
            DataHoraInclusao = DateTime.UtcNow,
            UsuarioInclusao = "System",
            DataHoraAlteracao = DateTime.UtcNow,
            UsuarioAlteracao = "System",
            IsActive = true
        };

        _context.EstadosBrasileiros.Add(estado);
        await _context.SaveChangesAsync();

        var estadoResponse = new EstadosBrasileirosResponseViewModel
        {
            Id = estado.Id,
            UF = estado.UF,
            Nome = estado.Nome
        };

        return CreatedAtAction(nameof(GetById), new { id = estado.Id }, estadoResponse);
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<EstadosBrasileirosResponseViewModel>>> GetAll()
    {
        var estados = await _context.EstadosBrasileiros
            .Select(e => new EstadosBrasileirosResponseViewModel
            {
                Id = e.Id,
                UF = e.UF,
                Nome = e.Nome
            })
            .ToListAsync();

        return Ok(estados);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<EstadosBrasileirosResponseViewModel>> GetById(int id)
    {
        var estado = await _context.EstadosBrasileiros
            .Where(e => e.Id == id)
            .Select(e => new EstadosBrasileirosResponseViewModel
            {
                Id = e.Id,
                UF = e.UF,
                Nome = e.Nome
            })
            .FirstOrDefaultAsync();

        if (estado == null)
        {
            return NotFound("Estado não encontrado.");
        }

        return Ok(estado);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, [FromBody] EstadosBrasileirosRequestViewModel estadoRequest)
    {
        if (!EntityExists(id))
        {
            return NotFound("Estado não encontrado.");
        }

        var estado = await _context.EstadosBrasileiros.FindAsync(id);
        if (estado == null)
        {
            return NotFound("Estado não encontrado.");
        }

        estado.UF = estadoRequest.UF;
        estado.Nome = estadoRequest.Nome;
        estado.DataHoraAlteracao = DateTime.UtcNow;
        estado.UsuarioAlteracao = "System";

        _context.Entry(estado).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!EntityExists(id))
            {
                return NotFound();
            }
            throw;
        }

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        if (!EntityExists(id))
        {
            return NotFound("Estado não encontrado.");
        }

        var estado = await _context.EstadosBrasileiros.FindAsync(id);
        if (estado == null)
        {
            return NotFound("Estado não encontrado.");
        }

        _context.EstadosBrasileiros.Remove(estado);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool EntityExists(int id)
    {
        return _context.EstadosBrasileiros.Any(e => e.Id == id);
    }
}
