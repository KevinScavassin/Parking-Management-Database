namespace ParkingDB.Entities
{
    public class Reserva:Entity<int>
    {
        public DateTime DataHoraReserva { get; set; }
        public virtual Cliente Cliente { get; set; }
        public virtual Vaga Vaga { get; set; }
        public virtual StatusReserva StatusReserva { get; set; }
    }
}
