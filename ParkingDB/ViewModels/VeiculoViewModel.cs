namespace ParkingDB.ViewModels
{
    public class VeiculoRequestViewModel
    {
        public string Placa { get; set; }
        public string Cor { get; set; }
        public string Modelo { get; set; }
        public int ClienteId { get; set; }
        public int TipoVeiculoId { get; set; }
    }

    public class VeiculoResponseViewModel
    {
        public int Id { get; set; }
        public string Placa { get; set; }
        public string Cor { get; set; }
        public string Modelo { get; set; }
        public int ClienteId { get; set; }
        public string ClienteNome { get; set; }
        public int TipoVeiculoId { get; set; }
        public string TipoVeiculoDescricao { get; set; }
    }
}
