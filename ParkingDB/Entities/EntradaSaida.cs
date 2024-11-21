namespace ParkingDB.Entities
{
    public class EntradaSaida:Entity<int>
    {
        public DateTime DataHoraEntrada { get; set; }
        public DateTime? DataHoraSaida { get; set; }
        public virtual Vaga Vaga { get; set; }
        public virtual Veiculo Veiculo { get; set; }
        public virtual Cliente Cliente { get; set; }
        public virtual Pagamento Pagamento { get; set; }
        
    }
}
