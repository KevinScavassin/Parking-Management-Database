namespace ParkingDB.Entities
{
    public class EstadosBrasileiros:Entity<string>
    {
        public string UF { get; set; }
        public string Nome { get; set; }  
        public virtual ICollection<Endereco> Enderecos { get; set; }
    }
}
