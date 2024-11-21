namespace ParkingDB.Entities
{
    public class Vaga:Entity<int>
    {
        public virtual Estacionamento Estacionamento { get; set; }
        public virtual TipoVeiculo TipoVeiculo { get; set; }
        public virtual StatusVaga StatusVaga { get; set; }
    }
}
