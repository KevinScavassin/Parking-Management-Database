namespace ParkingDB.Entities
{
    public class Veiculo:Entity<int>
    {
        public string Placa { get; set; }
        public string Cor { get; set; }
        public string Modelo { get; set; }
        public virtual Cliente Cliente { get; set; }
        public virtual TipoVeiculo TipoVeiculo { get; set; }
    }
}
