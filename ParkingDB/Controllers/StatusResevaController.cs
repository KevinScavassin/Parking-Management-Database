using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ParkingDB.Data;
using ParkingDB.Entities;
using ParkingDB.ViewModels;

[ApiController]
[Route("api/[controller]")]
public class StatusReservaController : ControllerBase
{
    private readonly ParkingDBContext _context;

    public StatusReservaController(ParkingDBContext context)
    {
        _context = context;
    }

    [HttpPost]
    public async Task<ActionResult<StatusReservaResponseViewModel>> Post([FromBody] StatusReservaRequestViewModel statusReservaRequest)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var statusReserva = new StatusReserva
        {
            Descricao = statusReservaRequest.Descricao,
            DataHoraInclusao = DateTime.Now,
            UsuarioInclusao = "System",
            DataHoraAlteracao = DateTime.Now,
            UsuarioAlteracao = "System",
            IsActive = true
        };

        _context.StatusReservas.Add(statusReserva);
        await _context.SaveChangesAsync();

        var response = new StatusReservaResponseViewModel
        {
            Id = statusReserva.Id,
            Descricao = statusReserva.Descricao
        };

        return CreatedAtAction(nameof(GetById), new { id = statusReserva.Id }, response);
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<StatusReservaResponseViewModel>>> Get()
    {
        var statusReservas = await _context.StatusReservas
            .Select(s => new StatusReservaResponseViewModel
            {
                Id = s.Id,
                Descricao = s.Descricao
            })
            .ToListAsync();

        return Ok(statusReservas);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<StatusReservaResponseViewModel>> GetById(int id)
    {
        var statusReserva = await _context.StatusReservas
            .Where(s => s.Id == id)
            .Select(s => new StatusReservaResponseViewModel
            {
                Id = s.Id,
                Descricao = s.Descricao
            })
            .FirstOrDefaultAsync();

        if (statusReserva == null)
        {
            return NotFound("Status de reserva não encontrado.");
        }

        return Ok(statusReserva);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, [FromBody] StatusReservaRequestViewModel statusReservaRequest)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var statusReserva = await _context.StatusReservas.FindAsync(id);
        if (statusReserva == null)
        {
            return NotFound("Status de reserva não encontrado.");
        }

        statusReserva.Descricao = statusReservaRequest.Descricao;
        statusReserva.DataHoraAlteracao = DateTime.Now;
        statusReserva.UsuarioAlteracao = "System";

        _context.StatusReservas.Update(statusReserva);
        await _context.SaveChangesAsync();

        var response = new StatusReservaResponseViewModel
        {
            Id = statusReserva.Id,
            Descricao = statusReserva.Descricao
        };

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var statusReserva = await _context.StatusReservas.FindAsync(id);
        if (statusReserva == null)
        {
            return NotFound("Status de reserva não encontrado.");
        }

        _context.StatusReservas.Remove(statusReserva);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}
