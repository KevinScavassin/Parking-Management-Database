namespace ParkingDB.Entities
{
    public class EntradaSaida:Entity<int>
    {
        public int IDEntradaSaida { get; set; }
        public int IDVaga { get; set; }
        public int IDVeiculo { get; set; }
        public DateTime DataHoraEntrada { get; set; }
        public DateTime? DataHoraSaida { get; set; }
        
    }
}
