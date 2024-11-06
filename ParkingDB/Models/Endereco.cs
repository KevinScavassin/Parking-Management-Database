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
    }
}
