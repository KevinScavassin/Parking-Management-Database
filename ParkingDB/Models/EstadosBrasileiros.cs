namespace ParkingDB.Models
{
    public class EstadosBrasileiros
    {
        public char UF { get; set; }
        public string Nome { get; set; }
        public DateTime DataHoraInclusão { get; set; }
        public string UsuarioInclusao { get; set; }
        public DateTime DataHoraAlteracao { get; set; }
        public string UsuarioAlteracao { get; set; }
        public Boolean IsActive { get; set; }
        public ICollection<Endereco> Enderecos { get; set; }
    }
}
