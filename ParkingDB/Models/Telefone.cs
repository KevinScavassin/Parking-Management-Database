namespace ParkingDB.Models
{
    public class Telefone
    {
        public int IDTelefone { get; set; }
        public int IDCliente {  get; set; }
        public string DDD {  get; set; }
        public string NumeroTelefone { get; set; }
        public DateTime DataHoraInclusão { get; set; }
        public string UsuarioInclusao { get; set; }
        public DateTime DataHoraAlteracao { get; set; }
        public string UsuarioAlteracao { get; set; }
        public Boolean IsActive { get; set; }

    }
}
