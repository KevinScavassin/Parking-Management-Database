namespace ParkingDB.Models
{
    public class Vaga
    {
        public int IDVaga { get; set; }
        public int IDEstacionamento { get; set; }
        public int IDTipoVeiculo { get; set; }
        public int IDStatusVaga { get; set; }
        public DateTime DataHoraInclusão { get; set; }
        public string UsuarioInclusao { get; set; }
        public DateTime DataHoraAlteracao { get; set; }
        public string UsuarioAlteracao { get; set; }
        public Boolean IsActive { get; set; }
        public Estacionamento Estacionamento { get; set; }
        public ICollection<EntradaSaida> EntradaSaidas { get; set; }
        public ICollection<Reserva> Reservas { get; set; }
    }
}
