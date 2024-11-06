namespace ParkingDB.Models
{
    public class Reserva
    {
        public int IDReserva { get; set; }
        public int IDCliente { get; set; }
        public int IDVaga { get; set; }
        public int IDStatusReserva { get; set; }
        public DateTime DataHoraReserva { get; set; }
    }
}
