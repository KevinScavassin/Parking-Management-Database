namespace ParkingDB.Entities
{
    public class Estacionamento:Entity<int>
    {
        public string Nome { get; set; }
        public int Capacidade { get; set; }
        public virtual Endereco Endereco { get; set; }
        public virtual ICollection<Vaga> Vagas { get; set; }  
    }
}
