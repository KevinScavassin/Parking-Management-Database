using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ParkingDB.Data;
using ParkingDB.Entities;
using ParkingDB.ViewModels;

[ApiController]
[Route("api/[controller]")]
public class EntradaSaidaController : ControllerBase
{
    private readonly ParkingDBContext _context;

    public EntradaSaidaController(ParkingDBContext context)
    {
        _context = context;
    }

    [HttpPost]
    public async Task<ActionResult<EntradaSaidaResponseViewModel>> Post([FromBody] EntradaSaidaRequestViewModel entradaSaidaRequest)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var vagaExistente = await _context.Vagas.FindAsync(entradaSaidaRequest.VagaId);
        if (vagaExistente == null)
        {
            return BadRequest("Vaga inválida.");
        }

        var veiculoExistente = await _context.Veiculos.FindAsync(entradaSaidaRequest.VeiculoId);
        if (veiculoExistente == null)
        {
            return BadRequest("Veículo inválido.");
        }

        var clienteExistente = await _context.Clientes.FindAsync(entradaSaidaRequest.ClienteId);
        if (clienteExistente == null)
        {
            return BadRequest("Cliente inválido.");
        }

        var pagamentoExistente = await _context.Pagamentos.FindAsync(entradaSaidaRequest.PagamentoId);
        if (pagamentoExistente == null)
        {
            return BadRequest("Pagamento inválido.");
        }

        var entradaSaida = new EntradaSaida
        {
            DataHoraEntrada = entradaSaidaRequest.DataHoraEntrada,
            DataHoraSaida = entradaSaidaRequest.DataHoraSaida,
            Vaga = vagaExistente,
            Veiculo = veiculoExistente,
            Cliente = clienteExistente,
            Pagamento = pagamentoExistente,
            DataHoraInclusao = DateTime.Now,
            UsuarioInclusao = "System",
            DataHoraAlteracao = DateTime.Now,
            UsuarioAlteracao = "System",
            IsActive = true
        };

        _context.EntradasSaidas.Add(entradaSaida);
        await _context.SaveChangesAsync();

        var response = new EntradaSaidaResponseViewModel
        {
            Id = entradaSaida.Id,
            DataHoraEntrada = entradaSaida.DataHoraEntrada,
            DataHoraSaida = entradaSaida.DataHoraSaida,
            VagaId = entradaSaida.Vaga.Id,
            VeiculoId = entradaSaida.Veiculo.Id,
            VeiculoPlaca = entradaSaida.Veiculo.Placa,       
            ClienteId = entradaSaida.Cliente.Id,
            ClienteNome = clienteExistente.Nome,            
            PagamentoId = entradaSaida.Pagamento.Id,
            PagamentoValor = entradaSaida.Pagamento.Valor 
        };

        return CreatedAtAction(nameof(GetById), new { id = entradaSaida.Id }, response);
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<EntradaSaidaResponseViewModel>>> Get()
    {
        var entradasSaidas = await _context.EntradasSaidas
            .Include(e => e.Vaga)
            .Include(e => e.Veiculo)
            .Include(e => e.Cliente)
            .Include(e => e.Pagamento)
            .Select(e => new EntradaSaidaResponseViewModel
            {
                Id = e.Id,
                DataHoraEntrada = e.DataHoraEntrada,
                DataHoraSaida = e.DataHoraSaida,
                VagaId = e.Vaga.Id,
                VeiculoId = e.Veiculo.Id,
                VeiculoPlaca = e.Veiculo.Placa,      
                ClienteId = e.Cliente.Id,
                ClienteNome = e.Cliente.Nome,       
                PagamentoId = e.Pagamento.Id,
                PagamentoValor = e.Pagamento.Valor
            })
            .ToListAsync();

        return Ok(entradasSaidas);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<EntradaSaidaResponseViewModel>> GetById(int id)
    {
        var entradaSaida = await _context.EntradasSaidas
            .Include(e => e.Vaga)
            .Include(e => e.Veiculo)
            .Include(e => e.Cliente)
            .Include(e => e.Pagamento)
            .Where(e => e.Id == id)
            .Select(e => new EntradaSaidaResponseViewModel
            {
                Id = e.Id,
                DataHoraEntrada = e.DataHoraEntrada,
                DataHoraSaida = e.DataHoraSaida,
                VagaId = e.Vaga.Id,
                VeiculoId = e.Veiculo.Id,
                VeiculoPlaca = e.Veiculo.Placa,      
                ClienteId = e.Cliente.Id,
                ClienteNome = e.Cliente.Nome,       
                PagamentoId = e.Pagamento.Id,
                PagamentoValor = e.Pagamento.Valor 
            })
            .FirstOrDefaultAsync();

        if (entradaSaida == null)
        {
            return NotFound("EntradaSaida não encontrada.");
        }

        return Ok(entradaSaida);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, [FromBody] EntradaSaidaRequestViewModel entradaSaidaRequest)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var entradaSaida = await _context.EntradasSaidas
            .Include(e => e.Vaga)
            .Include(e => e.Veiculo)
            .Include(e => e.Cliente)
            .Include(e => e.Pagamento)
            .FirstOrDefaultAsync(e => e.Id == id);

        if (entradaSaida == null)
        {
            return NotFound("EntradaSaida não encontrada.");
        }

        var vagaExistente = await _context.Vagas.FindAsync(entradaSaidaRequest.VagaId);
        if (vagaExistente == null)
        {
            return BadRequest("Vaga inválida.");
        }

        var veiculoExistente = await _context.Veiculos.FindAsync(entradaSaidaRequest.VeiculoId);
        if (veiculoExistente == null)
        {
            return BadRequest("Veículo inválido.");
        }

        var clienteExistente = await _context.Clientes.FindAsync(entradaSaidaRequest.ClienteId);
        if (clienteExistente == null)
        {
            return BadRequest("Cliente inválido.");
        }

        var pagamentoExistente = await _context.Pagamentos.FindAsync(entradaSaidaRequest.PagamentoId);
        if (pagamentoExistente == null)
        {
            return BadRequest("Pagamento inválido.");
        }

        entradaSaida.DataHoraEntrada = entradaSaidaRequest.DataHoraEntrada;
        entradaSaida.DataHoraSaida = entradaSaidaRequest.DataHoraSaida;
        entradaSaida.Vaga = vagaExistente;
        entradaSaida.Veiculo = veiculoExistente;
        entradaSaida.Cliente = clienteExistente;
        entradaSaida.Pagamento = pagamentoExistente;
        entradaSaida.DataHoraAlteracao = DateTime.Now;
        entradaSaida.UsuarioAlteracao = "System";

        _context.EntradasSaidas.Update(entradaSaida);
        await _context.SaveChangesAsync();

        var response = new EntradaSaidaResponseViewModel
        {
            Id = entradaSaida.Id,
            DataHoraEntrada = entradaSaida.DataHoraEntrada,
            DataHoraSaida = entradaSaida.DataHoraSaida,
            VagaId = entradaSaida.Vaga.Id,
            VeiculoId = entradaSaida.Veiculo.Id,
            VeiculoPlaca = entradaSaida.Veiculo.Placa, 
            ClienteId = entradaSaida.Cliente.Id,
            ClienteNome = entradaSaida.Cliente.Nome, 
            PagamentoId = entradaSaida.Pagamento.Id,
            PagamentoValor = entradaSaida.Pagamento.Valor
        };

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var entradaSaida = await _context.EntradasSaidas.FindAsync(id);
        if (entradaSaida == null)
        {
            return NotFound("EntradaSaida não encontrada.");
        }

        entradaSaida.IsActive = false;
        _context.EntradasSaidas.Update(entradaSaida);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}
