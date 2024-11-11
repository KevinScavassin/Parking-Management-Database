namespace ParkingDB.Entities
{
    public class StatusVaga:Entity<int>
    {
        public int IDStatusVaga { get; set; }
        public string Descricao { get; set; }
        public ICollection<Vaga> Vagas { get; set; }

    }
}
