namespace ParkingDB.Entities
{
    public class StatusReserva:Entity<int>
    {
        public int IDStatusReserva { get; set; }
        public string Descricao { get; set; }
        public ICollection<Reserva> Reservas { get; set; }
    }
}
