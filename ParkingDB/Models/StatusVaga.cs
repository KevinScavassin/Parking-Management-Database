namespace ParkingDB.Models
{
    public class StatusVaga
    {
        public int IDStatusVaga { get; set; }
        public string Descricao { get; set; }
        public ICollection<Vaga> Vagas { get; set; }

    }
}
