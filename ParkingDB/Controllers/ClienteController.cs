using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ParkingDB.Data;
using ParkingDB.Entities;
using ParkingDB.ViewModels;

[Route("api/[controller]")]
[ApiController]
public class ClienteController : ControllerBase
{
    private readonly ParkingDBContext _context;

    public ClienteController(ParkingDBContext context)
    {
        _context = context;
    }

    [HttpPost]
    public async Task<ActionResult<ClienteResponseViewModel>> Post([FromBody] ClienteRequestViewModel clienteRequest)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        if (string.IsNullOrWhiteSpace(clienteRequest.Nome))
        {
            ModelState.AddModelError("Nome", "O campo 'Nome' é obrigatório.");
            return BadRequest(ModelState);
        }

        var cliente = new Cliente
        {
            Nome = clienteRequest.Nome,
            CPF = string.IsNullOrWhiteSpace(clienteRequest.CPF) ? null : clienteRequest.CPF, // Permite null
            CNPJ = string.IsNullOrWhiteSpace(clienteRequest.CNPJ) ? null : clienteRequest.CNPJ, // Permite null
            DataHoraInclusao = DateTime.UtcNow,
            UsuarioInclusao = "System",
            DataHoraAlteracao = DateTime.UtcNow,
            UsuarioAlteracao = "System",
            IsActive = true
        };

        _context.Clientes.Add(cliente);
        await _context.SaveChangesAsync();

        var clienteResponse = new ClienteResponseViewModel
        {
            Id = cliente.Id,
            Nome = cliente.Nome,  // Adicionando o Nome na resposta
            CPF = cliente.CPF,
            CNPJ = cliente.CNPJ
        };

        return CreatedAtAction(nameof(GetById), new { id = cliente.Id }, clienteResponse);
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ClienteResponseViewModel>>> GetAll()
    {
        var clientes = await _context.Clientes
            .Select(c => new ClienteResponseViewModel
            {
                Id = c.Id,
                Nome = c.Nome,  // Incluindo o Nome na resposta
                CPF = c.CPF,
                CNPJ = c.CNPJ
            })
            .ToListAsync();

        return Ok(clientes);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ClienteResponseViewModel>> GetById(int id)
    {
        var cliente = await _context.Clientes.FindAsync(id);

        if (cliente == null)
        {
            return NotFound();
        }

        var clienteResponse = new ClienteResponseViewModel
        {
            Id = cliente.Id,
            Nome = cliente.Nome,  // Incluindo o Nome na resposta
            CPF = cliente.CPF,
            CNPJ = cliente.CNPJ
        };

        return Ok(clienteResponse);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, [FromBody] ClienteRequestViewModel clienteRequest)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        // Verificando se o nome é obrigatório
        if (string.IsNullOrWhiteSpace(clienteRequest.Nome))
        {
            ModelState.AddModelError("Nome", "O campo 'Nome' é obrigatório.");
            return BadRequest(ModelState);
        }

        var cliente = await _context.Clientes.FindAsync(id);
        if (cliente == null)
        {
            return NotFound();
        }

        cliente.Nome = clienteRequest.Nome;
        cliente.CPF = clienteRequest.CPF;
        cliente.CNPJ = clienteRequest.CNPJ;
        cliente.DataHoraAlteracao = DateTime.Now;
        cliente.UsuarioAlteracao = "System";

        _context.Entry(cliente).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!ClienteExists(id))
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
        var cliente = await _context.Clientes.FindAsync(id);
        if (cliente == null)
        {
            return NotFound();
        }

        _context.Clientes.Remove(cliente);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool ClienteExists(int id)
    {
        return _context.Clientes.Any(c => c.Id == id);
    }
}
