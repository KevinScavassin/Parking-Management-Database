using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ParkingDB.Data;
using ParkingDB.Entities;
using ParkingDB.ViewModels;

[ApiController]
[Route("api/[controller]")]
public class EnderecoController : ControllerBase
{
    private readonly ParkingDBContext _context;

    public EnderecoController(ParkingDBContext context)
    {
        _context = context;
    }

    [HttpPost]
    public async Task<ActionResult<EnderecoResponseViewModel>> Post([FromBody] EnderecoRequestViewModel enderecoRequest)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var estadoExistente = await _context.EstadosBrasileiros.FindAsync(enderecoRequest.EstadoId);
        if (estadoExistente == null)
        {
            return BadRequest("Estado inválido.");
        }

        var endereco = new Endereco
        {
            Rua = enderecoRequest.Rua,
            Numero = enderecoRequest.Numero,
            Complemento = string.IsNullOrWhiteSpace(enderecoRequest.Complemento) ? null : enderecoRequest.Complemento,
            CEP = enderecoRequest.CEP,
            Cidade = enderecoRequest.Cidade,
            Estados = estadoExistente,
            DataHoraInclusao = DateTime.Now,
            UsuarioInclusao = "System",
            DataHoraAlteracao = DateTime.Now,
            UsuarioAlteracao = "System",
            IsActive = true
        };

        _context.Enderecos.Add(endereco);
        await _context.SaveChangesAsync();

        var response = new EnderecoResponseViewModel
        {
            Id = endereco.Id,
            Rua = endereco.Rua,
            Numero = endereco.Numero,
            Complemento = endereco.Complemento,
            CEP = endereco.CEP,
            Cidade = endereco.Cidade,
            Estado = estadoExistente.Nome 
        };

        return CreatedAtAction(nameof(GetById), new { id = endereco.Id }, response);
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<EnderecoResponseViewModel>>> Get()
    {
        var enderecos = await _context.Enderecos
            .Include(e => e.Estados)
            .Select(e => new EnderecoResponseViewModel
            {
                Id = e.Id,
                Rua = e.Rua,
                Numero = e.Numero,
                Complemento = e.Complemento,
                CEP = e.CEP,
                Cidade = e.Cidade,
                Estado = e.Estados.Nome 
            })
            .ToListAsync();

        return Ok(enderecos);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<EnderecoResponseViewModel>> GetById(int id)
    {
        var endereco = await _context.Enderecos
            .Include(e => e.Estados)
            .Where(e => e.Id == id)
            .Select(e => new EnderecoResponseViewModel
            {
                Id = e.Id,
                Rua = e.Rua,
                Numero = e.Numero,
                Complemento = e.Complemento,
                CEP = e.CEP,
                Cidade = e.Cidade,
                Estado = e.Estados.Nome 
            })
            .FirstOrDefaultAsync();

        if (endereco == null)
        {
            return NotFound("Endereço não encontrado.");
        }

        return Ok(endereco);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, [FromBody] EnderecoRequestViewModel enderecoRequest)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var endereco = await _context.Enderecos.Include(e => e.Estados).FirstOrDefaultAsync(e => e.Id == id);
        if (endereco == null)
        {
            return NotFound("Endereço não encontrado.");
        }

        var estadoExistente = await _context.EstadosBrasileiros.FindAsync(enderecoRequest.EstadoId);
        if (estadoExistente == null)
        {
            return BadRequest("Estado inválido.");
        }

        endereco.Rua = enderecoRequest.Rua;
        endereco.Numero = enderecoRequest.Numero;
        endereco.Complemento = enderecoRequest.Complemento;
        endereco.CEP = enderecoRequest.CEP;
        endereco.Cidade = enderecoRequest.Cidade;
        endereco.Estados = estadoExistente;
        endereco.DataHoraAlteracao = DateTime.Now;
        endereco.UsuarioAlteracao = "System";

        _context.Enderecos.Update(endereco);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var endereco = await _context.Enderecos.FindAsync(id);
        if (endereco == null)
        {
            return NotFound("Endereço não encontrado.");
        }

        _context.Enderecos.Remove(endereco);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}
