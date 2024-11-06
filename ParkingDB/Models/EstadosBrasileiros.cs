namespace ParkingDB.Models
{
    public class EstadosBrasileiros
    {
        public char UF { get; set; }
        public string Nome { get; set; }
        public ICollection<Endereco> Enderecos { get; set; }
    }
}
