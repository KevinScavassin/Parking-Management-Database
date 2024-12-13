using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ParkingDB.Data;
using ParkingDB.Entities;
using ParkingDB.ViewModels;

[ApiController]
[Route("api/[controller]")]
public class VagaController : ControllerBase
{
    private readonly ParkingDBContext _context;

    public VagaController(ParkingDBContext context)
    {
        _context = context;
    }

    [HttpPost]
    public async Task<ActionResult<VagaResponseViewModel>> Post([FromBody] VagaRequestViewModel vagaRequest)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var estacionamentoExistente = await _context.Estacionamentos.FindAsync(vagaRequest.EstacionamentoId);
        var tipoVeiculoExistente = await _context.TipoVeiculos.FindAsync(vagaRequest.TipoVeiculoId);
        var statusVagaExistente = await _context.StatusVagas.FindAsync(vagaRequest.StatusVagaId);

        if (estacionamentoExistente == null || tipoVeiculoExistente == null || statusVagaExistente == null)
        {
            return BadRequest("Estacionamento, Tipo de Veículo ou Status de Vaga inválidos.");
        }

        var vaga = new Vaga
        {
            Estacionamento = estacionamentoExistente,
            TipoVeiculo = tipoVeiculoExistente,
            StatusVaga = statusVagaExistente,
            DataHoraInclusao = DateTime.Now,
            UsuarioInclusao = "System",
            DataHoraAlteracao = DateTime.Now,
            UsuarioAlteracao = "System",
            IsActive = true
        };

        _context.Vagas.Add(vaga);
        await _context.SaveChangesAsync();

        var response = new VagaResponseViewModel
        {
            Id = vaga.Id,
            EstacionamentoNome = vaga.Estacionamento.Nome,
            TipoVeiculoDescricao = vaga.TipoVeiculo.Descricao,
            StatusVagaDescricao = vaga.StatusVaga.Descricao
        };

        return CreatedAtAction(nameof(GetById), new { id = vaga.Id }, response);
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<VagaResponseViewModel>>> Get()
    {
        var vagas = await _context.Vagas
            .Include(v => v.Estacionamento)
            .Include(v => v.TipoVeiculo)
            .Include(v => v.StatusVaga)
            .Select(v => new VagaResponseViewModel
            {
                Id = v.Id,
                EstacionamentoNome = v.Estacionamento.Nome,
                TipoVeiculoDescricao = v.TipoVeiculo.Descricao,
                StatusVagaDescricao = v.StatusVaga.Descricao
            })
            .ToListAsync();

        return Ok(vagas);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<VagaResponseViewModel>> GetById(int id)
    {
        var vaga = await _context.Vagas
            .Include(v => v.Estacionamento)
            .Include(v => v.TipoVeiculo)
            .Include(v => v.StatusVaga)
            .Where(v => v.Id == id)
            .Select(v => new VagaResponseViewModel
            {
                Id = v.Id,
                EstacionamentoNome = v.Estacionamento.Nome,
                TipoVeiculoDescricao = v.TipoVeiculo.Descricao,
                StatusVagaDescricao = v.StatusVaga.Descricao
            })
            .FirstOrDefaultAsync();

        if (vaga == null)
        {
            return NotFound("Vaga não encontrada.");
        }

        return Ok(vaga);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, [FromBody] VagaRequestViewModel vagaRequest)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var vaga = await _context.Vagas
            .Include(v => v.Estacionamento)
            .Include(v => v.TipoVeiculo)
            .Include(v => v.StatusVaga)
            .FirstOrDefaultAsync(v => v.Id == id);

        if (vaga == null)
        {
            return NotFound("Vaga não encontrada.");
        }

        var estacionamentoExistente = await _context.Estacionamentos.FindAsync(vagaRequest.EstacionamentoId);
        var tipoVeiculoExistente = await _context.TipoVeiculos.FindAsync(vagaRequest.TipoVeiculoId);
        var statusVagaExistente = await _context.StatusVagas.FindAsync(vagaRequest.StatusVagaId);

        if (estacionamentoExistente == null || tipoVeiculoExistente == null || statusVagaExistente == null)
        {
            return BadRequest("Estacionamento, Tipo de Veículo ou Status de Vaga inválidos.");
        }

        vaga.Estacionamento = estacionamentoExistente;
        vaga.TipoVeiculo = tipoVeiculoExistente;
        vaga.StatusVaga = statusVagaExistente;
        vaga.DataHoraAlteracao = DateTime.Now;
        vaga.UsuarioAlteracao = "System";

        _context.Vagas.Update(vaga);
        await _context.SaveChangesAsync();

        var response = new VagaResponseViewModel
        {
            Id = vaga.Id,
            EstacionamentoNome = vaga.Estacionamento.Nome,
            TipoVeiculoDescricao = vaga.TipoVeiculo.Descricao,
            StatusVagaDescricao = vaga.StatusVaga.Descricao
        };

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var vaga = await _context.Vagas.FindAsync(id);
        if (vaga == null)
        {
            return NotFound("Vaga não encontrada.");
        }

        _context.Vagas.Remove(vaga);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}
