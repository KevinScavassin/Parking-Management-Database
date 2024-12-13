using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ParkingDB.Data;
using ParkingDB.Entities;
using ParkingDB.ViewModels;

[ApiController]
[Route("api/[controller]")]
public class EstacionamentoController : ControllerBase
{
    private readonly ParkingDBContext _context;

    public EstacionamentoController(ParkingDBContext context)
    {
        _context = context;
    }

    [HttpPost]
    public async Task<ActionResult<EstacionamentoResponseViewModel>> Post([FromBody] EstacionamentoRequestViewModel estacionamentoRequest)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var enderecoExistente = await _context.Enderecos.FindAsync(estacionamentoRequest.EnderecoId);
        if (enderecoExistente == null)
        {
            return BadRequest("Endereço inválido.");
        }

        var estacionamento = new Estacionamento
        {
            Nome = estacionamentoRequest.Nome,
            Capacidade = estacionamentoRequest.Capacidade,
            Endereco = enderecoExistente,
            DataHoraInclusao = DateTime.Now,
            UsuarioInclusao = "System",
            DataHoraAlteracao = DateTime.Now,
            UsuarioAlteracao = "System",
            IsActive = true
        };

        _context.Estacionamentos.Add(estacionamento);
        await _context.SaveChangesAsync();

        var response = new EstacionamentoResponseViewModel
        {
            Id = estacionamento.Id,
            Nome = estacionamento.Nome,
            Capacidade = estacionamento.Capacidade,
            EnderecoId = estacionamento.Endereco.Id,
            Endereco = estacionamento.Endereco.Rua + ", " + estacionamento.Endereco.Cidade
        };

        return CreatedAtAction(nameof(GetById), new { id = estacionamento.Id }, response);
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<EstacionamentoResponseViewModel>>> Get()
    {
        var estacionamentos = await _context.Estacionamentos
            .Include(e => e.Endereco)
            .Select(e => new EstacionamentoResponseViewModel
            {
                Id = e.Id,
                Nome = e.Nome,
                Capacidade = e.Capacidade,
                EnderecoId = e.Endereco.Id,
                Endereco = e.Endereco.Rua + ", " + e.Endereco.Cidade
            })
            .ToListAsync();

        return Ok(estacionamentos);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<EstacionamentoResponseViewModel>> GetById(int id)
    {
        var estacionamento = await _context.Estacionamentos
            .Include(e => e.Endereco)
            .Where(e => e.Id == id)
            .Select(e => new EstacionamentoResponseViewModel
            {
                Id = e.Id,
                Nome = e.Nome,
                Capacidade = e.Capacidade,
                EnderecoId = e.Endereco.Id,
                Endereco = e.Endereco.Rua + ", " + e.Endereco.Cidade
            })
            .FirstOrDefaultAsync();

        if (estacionamento == null)
        {
            return NotFound("Estacionamento não encontrado.");
        }

        return Ok(estacionamento);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, [FromBody] EstacionamentoRequestViewModel estacionamentoRequest)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var estacionamento = await _context.Estacionamentos
            .Include(e => e.Endereco)
            .FirstOrDefaultAsync(e => e.Id == id);

        if (estacionamento == null)
        {
            return NotFound("Estacionamento não encontrado.");
        }

        var enderecoExistente = await _context.Enderecos.FindAsync(estacionamentoRequest.EnderecoId);
        if (enderecoExistente == null)
        {
            return BadRequest("Endereço inválido.");
        }

        estacionamento.Nome = estacionamentoRequest.Nome;
        estacionamento.Capacidade = estacionamentoRequest.Capacidade;
        estacionamento.Endereco = enderecoExistente;
        estacionamento.DataHoraAlteracao = DateTime.Now;
        estacionamento.UsuarioAlteracao = "System";

        _context.Estacionamentos.Update(estacionamento);
        await _context.SaveChangesAsync();

        var response = new EstacionamentoResponseViewModel
        {
            Id = estacionamento.Id,
            Nome = estacionamento.Nome,
            Capacidade = estacionamento.Capacidade,
            EnderecoId = estacionamento.Endereco.Id,
            Endereco = estacionamento.Endereco.Rua + ", " + estacionamento.Endereco.Cidade
        };

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var estacionamento = await _context.Estacionamentos.FindAsync(id);
        if (estacionamento == null)
        {
            return NotFound("Estacionamento não encontrado.");
        }

        _context.Estacionamentos.Remove(estacionamento);
        await _context.SaveChangesAsync();

        return NoContent(); 
    }
}
