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
        public DateTime DataHoraInclusão { get; set; }
        public string UsuarioInclusao { get; set; }
        public DateTime DataHoraAlteracao { get; set; }
        public string UsuarioAlteracao { get; set; }
        public Boolean IsActive { get; set; }
        public ICollection<EntradaSaida> EntradaSaidas { get; set; }
    }
}
