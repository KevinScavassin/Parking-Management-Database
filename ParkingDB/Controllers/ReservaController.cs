using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ParkingDB.Data;
using ParkingDB.Entities;
using ParkingDB.ViewModels;

[ApiController]
[Route("api/[controller]")]
public class ReservaController : ControllerBase
{
    private readonly ParkingDBContext _context;

    public ReservaController(ParkingDBContext context)
    {
        _context = context;
    }

    // Criar uma nova reserva
    [HttpPost]
    public async Task<ActionResult<ReservaResponseViewModel>> Post([FromBody] ReservaRequestViewModel reservaRequest)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        // Verificar se o cliente existe
        var clienteExistente = await _context.Clientes.FindAsync(reservaRequest.ClienteId);
        if (clienteExistente == null)
        {
            return BadRequest("Cliente inválido.");
        }

        // Verificar se a vaga existe
        var vagaExistente = await _context.Vagas.FindAsync(reservaRequest.VagaId);
        if (vagaExistente == null)
        {
            return BadRequest("Vaga inválida.");
        }

        // Verificar se o status de reserva existe
        var statusReservaExistente = await _context.StatusReservas.FindAsync(reservaRequest.StatusReservaId);
        if (statusReservaExistente == null)
        {
            return BadRequest("Status de reserva inválido.");
        }

        // Criar a reserva
        var reserva = new Reserva
        {
            DataHoraReserva = reservaRequest.DataHoraReserva,
            Cliente = clienteExistente,
            Vaga = vagaExistente,
            StatusReserva = statusReservaExistente,
            DataHoraInclusao = DateTime.Now,
            UsuarioInclusao = "System",
            DataHoraAlteracao = DateTime.Now,
            UsuarioAlteracao = "System",
            IsActive = true
        };

        _context.Reservas.Add(reserva);
        await _context.SaveChangesAsync();

        // Preparar a resposta
        var response = new ReservaResponseViewModel
        {
            Id = reserva.Id,
            DataHoraReserva = reserva.DataHoraReserva,
            ClienteNome = clienteExistente.Nome,
            StatusReservaDescricao = statusReservaExistente.Descricao
        };

        return CreatedAtAction(nameof(GetById), new { id = reserva.Id }, response);
    }

    // Obter todas as reservas
    [HttpGet]
    public async Task<ActionResult<IEnumerable<ReservaResponseViewModel>>> Get()
    {
        var reservas = await _context.Reservas
            .Include(r => r.Cliente)
            .Include(r => r.Vaga)
            .Include(r => r.StatusReserva)
            .Select(r => new ReservaResponseViewModel
            {
                Id = r.Id,
                DataHoraReserva = r.DataHoraReserva,
                ClienteNome = r.Cliente.Nome,
                StatusReservaDescricao = r.StatusReserva.Descricao
            })
            .ToListAsync();

        return Ok(reservas);
    }

    // Obter uma reserva por ID
    [HttpGet("{id}")]
    public async Task<ActionResult<ReservaResponseViewModel>> GetById(int id)
    {
        var reserva = await _context.Reservas
            .Include(r => r.Cliente)
            .Include(r => r.Vaga)
            .Include(r => r.StatusReserva)
            .Where(r => r.Id == id)
            .Select(r => new ReservaResponseViewModel
            {
                Id = r.Id,
                DataHoraReserva = r.DataHoraReserva,
                ClienteNome = r.Cliente.Nome,
                StatusReservaDescricao = r.StatusReserva.Descricao
            })
            .FirstOrDefaultAsync();

        if (reserva == null)
        {
            return NotFound("Reserva não encontrada.");
        }

        return Ok(reserva);
    }

    // Atualizar uma reserva existente
    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, [FromBody] ReservaRequestViewModel reservaRequest)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var reserva = await _context.Reservas
            .Include(r => r.Cliente)
            .Include(r => r.Vaga)
            .Include(r => r.StatusReserva)
            .FirstOrDefaultAsync(r => r.Id == id);

        if (reserva == null)
        {
            return NotFound("Reserva não encontrada.");
        }

        var clienteExistente = await _context.Clientes.FindAsync(reservaRequest.ClienteId);
        var vagaExistente = await _context.Vagas.FindAsync(reservaRequest.VagaId);
        var statusReservaExistente = await _context.StatusReservas.FindAsync(reservaRequest.StatusReservaId);

        if (clienteExistente == null || vagaExistente == null || statusReservaExistente == null)
        {
            return BadRequest("Dados inválidos para a reserva.");
        }

        reserva.DataHoraReserva = reservaRequest.DataHoraReserva;
        reserva.Cliente = clienteExistente;
        reserva.Vaga = vagaExistente;
        reserva.StatusReserva = statusReservaExistente;
        reserva.DataHoraAlteracao = DateTime.Now;
        reserva.UsuarioAlteracao = "System";

        _context.Reservas.Update(reserva);
        await _context.SaveChangesAsync();

        var response = new ReservaResponseViewModel
        {
            Id = reserva.Id,
            DataHoraReserva = reserva.DataHoraReserva,
            ClienteNome = clienteExistente.Nome,
            StatusReservaDescricao = statusReservaExistente.Descricao
        };

        return Ok(response);
    }

    // Deletar uma reserva
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var reserva = await _context.Reservas.FindAsync(id);
        if (reserva == null)
        {
            return NotFound("Reserva não encontrada.");
        }

        _context.Reservas.Remove(reserva);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}
