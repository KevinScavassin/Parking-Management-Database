using ParkingDB.Data;
using ParkingDB.Entities;

namespace ParkingDB.Seeders
{
    public class DatabaseData
    {
        public static void Initialize(ParkingDBContext context)
        {
            SeedEstadosBrasileiros(context);
            SeedEnderecos(context);
            SeedClientes(context);
            SeedTelefones(context);
            SeedTipoVeiculo(context);
            SeedVeiculos(context);
            SeedMetodosPagamento(context);
            SeedStatusVaga(context);
            SeedEstacionamentos(context);
            SeedVagas(context);
            SeedStatusReserva(context);
            SeedReservas(context);
            SeedEntradasSaidas(context);
            SeedPagamentos(context);
        }

        private static void SeedEstadosBrasileiros(ParkingDBContext context)
        {
            context.EstadosBrasileiros.AddRange(
                new EstadosBrasileiros { UF = "SP", Nome = "São Paulo", DataHoraInclusao = DateTime.Now, UsuarioInclusao = "System",DataHoraAlteracao = DateTime.Now,UsuarioAlteracao ="System", IsActive = true },
                new EstadosBrasileiros { UF = "RJ", Nome = "Rio de Janeiro", DataHoraInclusao = DateTime.Now, UsuarioInclusao = "System", DataHoraAlteracao = DateTime.Now, UsuarioAlteracao = "System", IsActive = true },
                new EstadosBrasileiros { UF = "MG", Nome = "Minas Gerais", DataHoraInclusao = DateTime.Now, UsuarioInclusao = "System", DataHoraAlteracao = DateTime.Now, UsuarioAlteracao = "System", IsActive = true },
                new EstadosBrasileiros { UF = "BA", Nome = "Bahia", DataHoraInclusao = DateTime.Now, UsuarioInclusao = "System", DataHoraAlteracao = DateTime.Now, UsuarioAlteracao = "System", IsActive = true },
                new EstadosBrasileiros { UF = "RS", Nome = "Rio Grande do Sul", DataHoraInclusao = DateTime.Now, UsuarioInclusao = "System", DataHoraAlteracao = DateTime.Now, UsuarioAlteracao = "System", IsActive = true }
            );
        }

        private static void SeedEnderecos(ParkingDBContext context)
        {
            context.Enderecos.AddRange(
                new Endereco { Rua = "Rua das Flores", Numero = "123", Cidade = "São Paulo", UF = "SP", CEP = "01000-000", DataHoraInclusao = DateTime.Now, UsuarioInclusao = "System", DataHoraAlteracao = DateTime.Now, UsuarioAlteracao = "System", IsActive = true },
                new Endereco { Rua = "Avenida Brasil", Numero = "456", Cidade = "Rio de Janeiro", UF = "RJ", CEP = "22000-000", DataHoraInclusao = DateTime.Now, UsuarioInclusao = "System", DataHoraAlteracao = DateTime.Now, UsuarioAlteracao = "System", IsActive = true }
            );
        }

        private static void SeedClientes(ParkingDBContext context)
        {
            context.Clientes.AddRange(
                new Cliente { CPF = "123.456.789-00", DataHoraInclusao = DateTime.Now, UsuarioInclusao = "System", DataHoraAlteracao = DateTime.Now, UsuarioAlteracao = "System", IsActive = true },
                new Cliente { CPF = "987.654.321-00", DataHoraInclusao = DateTime.Now, UsuarioInclusao = "System", DataHoraAlteracao = DateTime.Now, UsuarioAlteracao = "System", IsActive = true },
                new Cliente { CPF = "456.123.789-00", DataHoraInclusao = DateTime.Now, UsuarioInclusao = "System", DataHoraAlteracao = DateTime.Now, UsuarioAlteracao = "System", IsActive = true },
                new Cliente { CPF = "654.321.987-00", DataHoraInclusao = DateTime.Now, UsuarioInclusao = "System", DataHoraAlteracao = DateTime.Now, UsuarioAlteracao = "System", IsActive = true },
                new Cliente { CPF = "789.456.123-00", DataHoraInclusao = DateTime.Now, UsuarioInclusao = "System", DataHoraAlteracao = DateTime.Now, UsuarioAlteracao = "System", IsActive = true }
            );
        }

        private static void SeedTelefones(ParkingDBContext context)
        {
            context.Telefones.AddRange(
                new Telefone { IDCliente = 1, DDD = "11", NumeroTelefone = "987654321", DataHoraInclusao = DateTime.Now, UsuarioInclusao = "System", DataHoraAlteracao = DateTime.Now, UsuarioAlteracao = "System", IsActive = true },
                new Telefone { IDCliente = 2, DDD = "21", NumeroTelefone = "912345678", DataHoraInclusao = DateTime.Now, UsuarioInclusao = "System", DataHoraAlteracao = DateTime.Now, UsuarioAlteracao = "System", IsActive = true },
                new Telefone { IDCliente = 3, DDD = "31", NumeroTelefone = "998765432", DataHoraInclusao = DateTime.Now, UsuarioInclusao = "System", DataHoraAlteracao = DateTime.Now, UsuarioAlteracao = "System", IsActive = true },
                new Telefone { IDCliente = 4, DDD = "71", NumeroTelefone = "987654321", DataHoraInclusao = DateTime.Now, UsuarioInclusao = "System", DataHoraAlteracao = DateTime.Now, UsuarioAlteracao = "System", IsActive = true },
                new Telefone { IDCliente = 5, DDD = "51", NumeroTelefone = "912345678", DataHoraInclusao = DateTime.Now, UsuarioInclusao = "System", DataHoraAlteracao = DateTime.Now, UsuarioAlteracao = "System", IsActive = true }
            );
        }

        private static void SeedTipoVeiculo(ParkingDBContext context)
        {
            context.TipoVeiculos.AddRange(
                new TipoVeiculo { Descricao = "Carro", DataHoraInclusao = DateTime.Now, UsuarioInclusao = "System", DataHoraAlteracao = DateTime.Now, UsuarioAlteracao = "System", IsActive = true },
                new TipoVeiculo { Descricao = "Moto", DataHoraInclusao = DateTime.Now, UsuarioInclusao = "System", DataHoraAlteracao = DateTime.Now, UsuarioAlteracao = "System", IsActive = true },
                new TipoVeiculo { Descricao = "Caminhão", DataHoraInclusao = DateTime.Now, UsuarioInclusao = "System", DataHoraAlteracao = DateTime.Now, UsuarioAlteracao = "System", IsActive = true }
            );
        }

        private static void SeedVeiculos(ParkingDBContext context)
        {
            context.Veiculos.AddRange(
                new Veiculo { IDCliente = 1, IDTipoVeiculo = 1, Placa = "ABC1234", Cor = "Preto", Modelo = "Sedan", DataHoraInclusao = DateTime.Now, UsuarioInclusao = "System", DataHoraAlteracao = DateTime.Now, UsuarioAlteracao = "System", IsActive = true },
                new Veiculo { IDCliente = 2, IDTipoVeiculo = 2, Placa = "XYZ5678", Cor = "Vermelho", Modelo = "Sport", DataHoraInclusao = DateTime.Now, UsuarioInclusao = "System", DataHoraAlteracao = DateTime.Now, UsuarioAlteracao = "System", IsActive = true },
                new Veiculo { IDCliente = 3, IDTipoVeiculo = 1, Placa = "LMN9876", Cor = "Azul", Modelo = "SUV", DataHoraInclusao = DateTime.Now, UsuarioInclusao = "System", DataHoraAlteracao = DateTime.Now, UsuarioAlteracao = "System", IsActive = true }
            );
        }

        private static void SeedMetodosPagamento(ParkingDBContext context)
        {
            context.MetodoPagamentos.AddRange(
                new MetodoPagamento { Descricao = "Dinheiro", DataHoraInclusao = DateTime.Now, UsuarioInclusao = "System", DataHoraAlteracao = DateTime.Now, UsuarioAlteracao = "System", IsActive = true },
                new MetodoPagamento { Descricao = "Cartão de Crédito", DataHoraInclusao = DateTime.Now, UsuarioInclusao = "System", DataHoraAlteracao = DateTime.Now, UsuarioAlteracao = "System", IsActive = true },
                new MetodoPagamento { Descricao = "PIX", DataHoraInclusao = DateTime.Now, UsuarioInclusao = "System", DataHoraAlteracao = DateTime.Now, UsuarioAlteracao = "System", IsActive = true }
            );
        }

        private static void SeedStatusVaga(ParkingDBContext context)
        {
            context.StatusVagas.AddRange(
                new StatusVaga { Descricao = "Disponível", DataHoraInclusao = DateTime.Now, UsuarioInclusao = "System", DataHoraAlteracao = DateTime.Now, UsuarioAlteracao = "System", IsActive = true },
                new StatusVaga { Descricao = "Ocupada", DataHoraInclusao = DateTime.Now, UsuarioInclusao = "System", DataHoraAlteracao = DateTime.Now, UsuarioAlteracao = "System", IsActive = true },
                new StatusVaga { Descricao = "Reservada", DataHoraInclusao = DateTime.Now, UsuarioInclusao = "System", DataHoraAlteracao = DateTime.Now, UsuarioAlteracao = "System", IsActive = true }
            );
        }

        private static void SeedEstacionamentos(ParkingDBContext context)
        {
            context.Estacionamentos.AddRange(
                new Estacionamento { IDEndereco = 1, Nome = "Estacionamento Central", Capacidade = 100, DataHoraInclusao = DateTime.Now, UsuarioInclusao = "System", DataHoraAlteracao = DateTime.Now, UsuarioAlteracao = "System", IsActive = true },
                new Estacionamento { IDEndereco = 2, Nome = "Estacionamento Norte", Capacidade = 50, DataHoraInclusao = DateTime.Now, UsuarioInclusao = "System", DataHoraAlteracao = DateTime.Now, UsuarioAlteracao = "System", IsActive = true }
            );
        }

        private static void SeedVagas(ParkingDBContext context)
        {
            context.Vagas.AddRange(
                new Vaga { IDEstacionamento = 1, IDTipoVeiculo = 1, IDStatusVaga = 1, DataHoraInclusao = DateTime.Now, UsuarioInclusao = "System", DataHoraAlteracao = DateTime.Now, UsuarioAlteracao = "System", IsActive = true },
                new Vaga { IDEstacionamento = 1, IDTipoVeiculo = 2, IDStatusVaga = 2, DataHoraInclusao = DateTime.Now, UsuarioInclusao = "System", DataHoraAlteracao = DateTime.Now, UsuarioAlteracao = "System", IsActive = true },
                new Vaga { IDEstacionamento = 1, IDTipoVeiculo = 3, IDStatusVaga = 2, DataHoraInclusao = DateTime.Now, UsuarioInclusao = "System", DataHoraAlteracao = DateTime.Now, UsuarioAlteracao = "System", IsActive = true },
                new Vaga { IDEstacionamento = 2, IDTipoVeiculo = 1, IDStatusVaga = 1, DataHoraInclusao = DateTime.Now, UsuarioInclusao = "System", DataHoraAlteracao = DateTime.Now, UsuarioAlteracao = "System", IsActive = true },
                new Vaga { IDEstacionamento = 2, IDTipoVeiculo = 2, IDStatusVaga = 1, DataHoraInclusao = DateTime.Now, UsuarioInclusao = "System", DataHoraAlteracao = DateTime.Now, UsuarioAlteracao = "System", IsActive = true },
                new Vaga { IDEstacionamento = 2, IDTipoVeiculo = 3, IDStatusVaga = 2, DataHoraInclusao = DateTime.Now, UsuarioInclusao = "System", DataHoraAlteracao = DateTime.Now, UsuarioAlteracao = "System", IsActive = true }
            );
        }

        private static void SeedStatusReserva(ParkingDBContext context)
        {
            context.StatusReservas.AddRange(
                new StatusReserva { Descricao = "Confirmada", DataHoraInclusao = DateTime.Now, UsuarioInclusao = "System", DataHoraAlteracao = DateTime.Now, UsuarioAlteracao = "System", IsActive = true },
                new StatusReserva { Descricao = "Pendente", DataHoraInclusao = DateTime.Now, UsuarioInclusao = "System", DataHoraAlteracao = DateTime.Now, UsuarioAlteracao = "System", IsActive = true },
                new StatusReserva { Descricao = "Cancelada", DataHoraInclusao = DateTime.Now, UsuarioInclusao = "System", DataHoraAlteracao = DateTime.Now, UsuarioAlteracao = "System", IsActive = true }
            );
        }

        private static void SeedReservas(ParkingDBContext context)
        {
            context.Reservas.AddRange(
                new Reserva { IDCliente = 1, IDVaga = 1, IDStatusReserva = 1, DataHoraReserva = DateTime.Now.AddDays(-1), DataHoraInclusao = DateTime.Now, UsuarioInclusao = "System", DataHoraAlteracao = DateTime.Now, UsuarioAlteracao = "System", IsActive = true },
                new Reserva { IDCliente = 2, IDVaga = 2, IDStatusReserva = 1, DataHoraReserva = DateTime.Now.AddHours(-2), DataHoraInclusao = DateTime.Now, UsuarioInclusao = "System", DataHoraAlteracao = DateTime.Now, UsuarioAlteracao = "System", IsActive = true }
            );
        }

        private static void SeedEntradasSaidas(ParkingDBContext context)
        {
            context.EntradasSaidas.AddRange(
                new EntradaSaida { IDVaga = 1, IDVeiculo = 1, DataHoraEntrada = DateTime.Now.AddHours(-3), DataHoraSaida = DateTime.Now.AddHours(-1), DataHoraInclusao = DateTime.Now, UsuarioInclusao = "System", DataHoraAlteracao = DateTime.Now, UsuarioAlteracao = "System", IsActive = true },
                new EntradaSaida { IDVaga = 2, IDVeiculo = 2, DataHoraEntrada = DateTime.Now.AddHours(-4), DataHoraSaida = DateTime.Now.AddHours(-2), DataHoraInclusao = DateTime.Now, UsuarioInclusao = "System", DataHoraAlteracao = DateTime.Now, UsuarioAlteracao = "System", IsActive = true }
            );
        }

        private static void SeedPagamentos(ParkingDBContext context)
        {
            context.Pagamentos.AddRange(
                new Pagamento { IDCliente = 1, IDMetodoPagamento = 2, IDEntradaSaida = 1, Valor = 56 , DataHoraInclusao = DateTime.Now, UsuarioInclusao = "System", DataHoraAlteracao = DateTime.Now, UsuarioAlteracao = "System", IsActive = true },
                new Pagamento { IDCliente = 2, IDMetodoPagamento = 1, IDEntradaSaida = 2, Valor = 72 , DataHoraInclusao = DateTime.Now, UsuarioInclusao = "System", DataHoraAlteracao = DateTime.Now, UsuarioAlteracao = "System", IsActive = true }
            );
        }

    }
}
