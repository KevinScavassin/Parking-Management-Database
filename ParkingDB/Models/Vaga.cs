namespace ParkingDB.Models
{
    public class Vaga
    {
        public int IDVaga { get; set; }
        public int IDEstacionamento { get; set; }
        public int IDTipoVeiculo { get; set; }
        public int IDStatusVaga { get; set; }
        public Estacionamento Estacionamento { get; set; }
        public ICollection<EntradaSaida> EntradaSaidas { get; set; }
        public ICollection<Reserva> Reservas { get; set; }
    }
}
