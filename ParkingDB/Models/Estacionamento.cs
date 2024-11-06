namespace ParkingDB.Models
{
    public class Estacionamento
    {
        public int IDEstacionamento { get; set; }
        public int IDEndereco { get; set; }
        public string Nome { get; set; }
        public int Capacidade { get; set; }
        public Endereco Endereco { get; set; }
    }
}
