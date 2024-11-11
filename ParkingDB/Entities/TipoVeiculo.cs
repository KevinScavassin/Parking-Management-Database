namespace ParkingDB.Entities
{
    public class TipoVeiculo:Entity<int>
    {
        public int IDTipoVeiculo { get; set; }
        public string Descricao { get; set; }
        public ICollection<Vaga> Vagas { get; set; }
        public ICollection<Veiculo> Veiculos { get; set; }
    }
}
