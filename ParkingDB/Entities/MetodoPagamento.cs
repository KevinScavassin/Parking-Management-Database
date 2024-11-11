namespace ParkingDB.Entities
{
    public class MetodoPagamento:Entity<int>
    {
        public int IDMetodoPagamento { get; set; }
        public string Descricao { get; set; }
        public ICollection<Pagamento> Pagamentos { get; set; }

    }
}
