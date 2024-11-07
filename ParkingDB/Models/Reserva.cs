namespace ParkingDB.Models
{
    public class Reserva
    {
        public int IDReserva { get; set; }
        public int IDCliente { get; set; }
        public int IDVaga { get; set; }
        public int IDStatusReserva { get; set; }
        public DateTime DataHoraReserva { get; set; }
        public DateTime DataHoraInclusão { get; set; }
        public string UsuarioInclusao { get; set; }
        public DateTime DataHoraAlteracao { get; set; }
        public string UsuarioAlteracao { get; set; }
        public Boolean IsActive { get; set; }
    }
}
