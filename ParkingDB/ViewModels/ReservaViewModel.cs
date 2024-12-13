namespace ParkingDB.ViewModels
{
    public class ReservaRequestViewModel
    {
        public DateTime DataHoraReserva { get; set; }
        public int ClienteId { get; set; }
        public int VagaId { get; set; }
        public int StatusReservaId { get; set; }
    }

    public class ReservaResponseViewModel
    {
        public int Id { get; set; }
        public DateTime DataHoraReserva { get; set; }
        public string ClienteNome { get; set; }
        public string StatusReservaDescricao { get; set; }
    }
}
