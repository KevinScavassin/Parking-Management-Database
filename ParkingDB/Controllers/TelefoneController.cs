using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ParkingDB.Data;
using ParkingDB.Entities;
using ParkingDB.ViewModels;

[ApiController]
[Route("api/[controller]")]
public class TelefoneController : ControllerBase
{
    private readonly ParkingDBContext _context;

    public TelefoneController(ParkingDBContext context)
    {
        _context = context;
    }

    [HttpPost]
    public async Task<ActionResult<TelefoneResponseViewModel>> Post([FromBody] TelefoneRequestViewModel telefoneRequest)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var clienteExistente = await _context.Clientes.FindAsync(telefoneRequest.ClienteId);
        if (clienteExistente == null)
        {
            return BadRequest("Cliente não encontrado.");
        }

        var telefone = new Telefone
        {
            DDD = telefoneRequest.DDD,
            NumeroTelefone = telefoneRequest.NumeroTelefone,
            Cliente = clienteExistente,
            DataHoraInclusao = DateTime.Now,
            UsuarioInclusao = "System",
            DataHoraAlteracao = DateTime.Now,
            UsuarioAlteracao = "System",
            IsActive = true
        };

        _context.Telefones.Add(telefone);
        await _context.SaveChangesAsync();

        var response = new TelefoneResponseViewModel
        {
            Id = telefone.Id,
            DDD = telefone.DDD,
            NumeroTelefone = telefone.NumeroTelefone,
            ClienteNome = clienteExistente.Nome
        };

        return CreatedAtAction(nameof(GetById), new { id = telefone.Id }, response);
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<TelefoneResponseViewModel>>> Get()
    {
        var telefones = await _context.Telefones
            .Include(t => t.Cliente)
            .Select(t => new TelefoneResponseViewModel
            {
                Id = t.Id,
                DDD = t.DDD,
                NumeroTelefone = t.NumeroTelefone,
                ClienteNome = t.Cliente.Nome
            })
            .ToListAsync();

        return Ok(telefones);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<TelefoneResponseViewModel>> GetById(int id)
    {
        var telefone = await _context.Telefones
            .Include(t => t.Cliente)
            .Where(t => t.Id == id)
            .Select(t => new TelefoneResponseViewModel
            {
                Id = t.Id,
                DDD = t.DDD,
                NumeroTelefone = t.NumeroTelefone,
                ClienteNome = t.Cliente.Nome
            })
            .FirstOrDefaultAsync();

        if (telefone == null)
        {
            return NotFound("Telefone não encontrado.");
        }

        return Ok(telefone);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, [FromBody] TelefoneRequestViewModel telefoneRequest)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var telefone = await _context.Telefones.Include(t => t.Cliente).FirstOrDefaultAsync(t => t.Id == id);
        if (telefone == null)
        {
            return NotFound("Telefone não encontrado.");
        }

        var clienteExistente = await _context.Clientes.FindAsync(telefoneRequest.ClienteId);
        if (clienteExistente == null)
        {
            return BadRequest("Cliente não encontrado.");
        }

        telefone.DDD = telefoneRequest.DDD;
        telefone.NumeroTelefone = telefoneRequest.NumeroTelefone;
        telefone.Cliente = clienteExistente;
        telefone.DataHoraAlteracao = DateTime.Now;
        telefone.UsuarioAlteracao = "System";

        _context.Telefones.Update(telefone);
        await _context.SaveChangesAsync();

        var response = new TelefoneResponseViewModel
        {
            Id = telefone.Id,
            DDD = telefone.DDD,
            NumeroTelefone = telefone.NumeroTelefone,
            ClienteNome = telefone.Cliente.Nome
        };

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var telefone = await _context.Telefones.FindAsync(id);
        if (telefone == null)
        {
            return NotFound("Telefone não encontrado.");
        }

        _context.Telefones.Remove(telefone);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}
