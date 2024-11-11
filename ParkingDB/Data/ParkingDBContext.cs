using Microsoft.EntityFrameworkCore;
using ParkingDB.Entities;
using ParkingDB.Configurations;

namespace ParkingDB.Data
{
    public class ParkingDBContext(DbContextOptions<ParkingDBContext> options) : DbContext(options)
    {
        public DbSet<EstadosBrasileiros> EstadosBrasileiros { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Veiculo> Veiculos { get; set; }
        public DbSet<Telefone> Telefones { get; set; }
        public DbSet<TipoVeiculo> TipoVeiculos { get; set; }
        public DbSet<Vaga> Vagas { get; set; }
        public DbSet<StatusVaga> StatusVagas { get; set; }
        public DbSet<Estacionamento> Estacionamentos { get; set; }
        public DbSet<Reserva> Reservas { get; set; }
        public DbSet<StatusReserva> StatusReservas { get; set; }
        public DbSet<MetodoPagamento> MetodoPagamentos { get; set; }
        public DbSet<Pagamento> Pagamentos { get; set; }
        public DbSet<EntradaSaida> EntradasSaidas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new EstadosBrasileirosConfiguration());
            modelBuilder.ApplyConfiguration(new EnderecoConfiguration());
            modelBuilder.ApplyConfiguration(new ClienteConfiguration());
            modelBuilder.ApplyConfiguration(new VeiculoConfiguration());
            modelBuilder.ApplyConfiguration(new TelefoneConfiguration());
            modelBuilder.ApplyConfiguration(new TipoVeiculoConfiguration());
            modelBuilder.ApplyConfiguration(new VagaConfiguration());
            modelBuilder.ApplyConfiguration(new StatusVagaConfiguration());
            modelBuilder.ApplyConfiguration(new EstacionamentoConfiguration());
            modelBuilder.ApplyConfiguration(new ReservaConfiguration());
            modelBuilder.ApplyConfiguration(new StatusReservaConfiguration());
            modelBuilder.ApplyConfiguration(new MetodoPagamentoConfiguration());
            modelBuilder.ApplyConfiguration(new PagamentoConfiguration());
            modelBuilder.ApplyConfiguration(new EntradaSaidaConfiguration());
        }
    }
}
