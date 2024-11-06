namespace ParkingDB.Models
{
    public class Veiculo
    {
        public int IDVeiculo { get; set; }
        public int IDCliente { get; set; }
        public int IDTipoVeiculo { get; set; }
        public string Placa { get; set; }
        public string Cor { get; set; }
        public string Modelo { get; set; }
        public ICollection<EntradaSaida> EntradaSaidas { get; set; }
    }
}
