namespace ParkingDB.Models
{
    public class Endereco
    {
        public int IDEndereco { get; set; }
        public string Rua { get; set; }
        public string Numero { get; set; }
        public string Cidade { get; set; }
        public char UF { get; set; } 
        public string CEP { get; set; }
        public string Complemento { get; set; }
        public DateTime DataHoraInclusão { get; set; }
        public string UsuarioInclusao { get; set; }
        public DateTime DataHoraAlteracao { get; set; }
        public string UsuarioAlteracao { get; set; }
        public Boolean IsActive { get; set; }
    }
}
