namespace ParkingDB.Models
{
    public class Estacionamento
    {
        public int IDEstacionamento { get; set; }
        public int IDEndereco { get; set; }
        public string Nome { get; set; }
        public int Capacidade { get; set; }
        public DateTime DataHoraInclusão { get; set; }
        public string UsuarioInclusao { get; set; }
        public DateTime DataHoraAlteracao { get; set; }
        public string UsuarioAlteracao { get; set; }
        public Boolean IsActive { get; set; }
        public Endereco Endereco { get; set; }
    }
}
