using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ParkingDB.Data;
using ParkingDB.Entities;
using ParkingDB.ViewModels;

[ApiController]
[Route("api/[controller]")]
public class VeiculoController : ControllerBase
{
    private readonly ParkingDBContext _context;

    public VeiculoController(ParkingDBContext context)
    {
        _context = context;
    }

    [HttpPost]
    public async Task<ActionResult<VeiculoResponseViewModel>> Post([FromBody] VeiculoRequestViewModel veiculoRequest)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var clienteExistente = await _context.Clientes.FindAsync(veiculoRequest.ClienteId);
        var tipoVeiculoExistente = await _context.TipoVeiculos.FindAsync(veiculoRequest.TipoVeiculoId);

        if (clienteExistente == null || tipoVeiculoExistente == null)
        {
            return BadRequest("Cliente ou Tipo de Veículo inválidos.");
        }

        var veiculo = new Veiculo
        {
            Placa = veiculoRequest.Placa,
            Cor = veiculoRequest.Cor,
            Modelo = veiculoRequest.Modelo,
            Cliente = clienteExistente,
            TipoVeiculo = tipoVeiculoExistente,
            DataHoraInclusao = DateTime.Now,
            UsuarioInclusao = "System",
            DataHoraAlteracao = DateTime.Now,
            UsuarioAlteracao = "System",
            IsActive = true
        };

        _context.Veiculos.Add(veiculo);
        await _context.SaveChangesAsync();

        var response = new VeiculoResponseViewModel
        {
            Id = veiculo.Id,
            Placa = veiculo.Placa,
            Cor = veiculo.Cor,
            Modelo = veiculo.Modelo,
            ClienteId = veiculo.Cliente.Id,
            ClienteNome = veiculo.Cliente.Nome,
            TipoVeiculoId = veiculo.TipoVeiculo.Id,
            TipoVeiculoDescricao = veiculo.TipoVeiculo.Descricao
        };

        return CreatedAtAction(nameof(GetById), new { id = veiculo.Id }, response);
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<VeiculoResponseViewModel>>> Get()
    {
        var veiculos = await _context.Veiculos
            .Include(v => v.Cliente)
            .Include(v => v.TipoVeiculo)
            .Select(v => new VeiculoResponseViewModel
            {
                Id = v.Id,
                Placa = v.Placa,
                Cor = v.Cor,
                Modelo = v.Modelo,
                ClienteId = v.Cliente.Id,
                ClienteNome = v.Cliente.Nome,
                TipoVeiculoId = v.TipoVeiculo.Id,
                TipoVeiculoDescricao = v.TipoVeiculo.Descricao
            })
            .ToListAsync();

        return Ok(veiculos);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<VeiculoResponseViewModel>> GetById(int id)
    {
        var veiculo = await _context.Veiculos
            .Include(v => v.Cliente)
            .Include(v => v.TipoVeiculo)
            .Where(v => v.Id == id)
            .Select(v => new VeiculoResponseViewModel
            {
                Id = v.Id,
                Placa = v.Placa,
                Cor = v.Cor,
                Modelo = v.Modelo,
                ClienteId = v.Cliente.Id,
                ClienteNome = v.Cliente.Nome,
                TipoVeiculoId = v.TipoVeiculo.Id,
                TipoVeiculoDescricao = v.TipoVeiculo.Descricao
            })
            .FirstOrDefaultAsync();

        if (veiculo == null)
        {
            return NotFound("Veículo não encontrado.");
        }

        return Ok(veiculo);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, [FromBody] VeiculoRequestViewModel veiculoRequest)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var veiculo = await _context.Veiculos.Include(v => v.Cliente).Include(v => v.TipoVeiculo).FirstOrDefaultAsync(v => v.Id == id);
        if (veiculo == null)
        {
            return NotFound("Veículo não encontrado.");
        }

        var clienteExistente = await _context.Clientes.FindAsync(veiculoRequest.ClienteId);
        var tipoVeiculoExistente = await _context.TipoVeiculos.FindAsync(veiculoRequest.TipoVeiculoId);

        if (clienteExistente == null || tipoVeiculoExistente == null)
        {
            return BadRequest("Cliente ou Tipo de Veículo inválidos.");
        }

        veiculo.Placa = veiculoRequest.Placa;
        veiculo.Cor = veiculoRequest.Cor;
        veiculo.Modelo = veiculoRequest.Modelo;
        veiculo.Cliente = clienteExistente;
        veiculo.TipoVeiculo = tipoVeiculoExistente;
        veiculo.DataHoraAlteracao = DateTime.Now;
        veiculo.UsuarioAlteracao = "System";

        _context.Veiculos.Update(veiculo);
        await _context.SaveChangesAsync();

        var response = new VeiculoResponseViewModel
        {
            Id = veiculo.Id,
            Placa = veiculo.Placa,
            Cor = veiculo.Cor,
            Modelo = veiculo.Modelo,
            ClienteId = veiculo.Cliente.Id,
            ClienteNome = veiculo.Cliente.Nome,
            TipoVeiculoId = veiculo.TipoVeiculo.Id,
            TipoVeiculoDescricao = veiculo.TipoVeiculo.Descricao
        };

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var veiculo = await _context.Veiculos.FindAsync(id);
        if (veiculo == null)
        {
            return NotFound("Veículo não encontrado.");
        }

        _context.Veiculos.Remove(veiculo);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}
