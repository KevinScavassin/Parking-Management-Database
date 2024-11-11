namespace ParkingDB.Entities
{
    public class Estacionamento:Entity<int>
    {
        public int IDEstacionamento { get; set; }
        public int IDEndereco { get; set; }
        public string Nome { get; set; }
        public int Capacidade { get; set; }
        public Endereco Endereco { get; set; }
    }
}
