namespace ParkingDB.Entities
{
    public class EstadosBrasileiros:Entity<string>
    {
        public string UF { get; set; }
        public string Nome { get; set; }        
        public ICollection<Endereco> Enderecos { get; set; }
    }
}
