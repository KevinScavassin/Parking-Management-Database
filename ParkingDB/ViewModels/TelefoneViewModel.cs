namespace ParkingDB.ViewModels
{
    public class TelefoneRequestViewModel
    {
        public string DDD { get; set; }
        public string NumeroTelefone { get; set; }
        public int ClienteId { get; set; }
    }

    public class TelefoneResponseViewModel
    {
        public int Id { get; set; }
        public string DDD { get; set; }
        public string NumeroTelefone { get; set; }
        public string ClienteNome { get; set; }
    }
}
