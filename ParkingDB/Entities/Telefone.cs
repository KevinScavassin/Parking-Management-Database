namespace ParkingDB.Entities
{
    public class Telefone:Entity<int>
    {
        public int IDTelefone { get; set; }
        public int IDCliente {  get; set; }
        public string DDD {  get; set; }
        public string NumeroTelefone { get; set; }
    }
}
