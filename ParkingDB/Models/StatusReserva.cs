namespace ParkingDB.Models
{
    public class StatusReserva
    {
        public int IDStatusReserva { get; set; }
        public string Descricao { get; set; }
        public ICollection<Reserva> Reservas { get; set; }
    }
}
