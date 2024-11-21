namespace ParkingDB.Entities
{
    public class Telefone:Entity<int>
    {
        public string DDD {  get; set; }
        public string NumeroTelefone { get; set; }
        public virtual Cliente Cliente { get; set; }
    }
}
