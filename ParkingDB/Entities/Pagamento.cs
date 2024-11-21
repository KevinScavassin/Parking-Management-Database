namespace ParkingDB.Entities
{
    public class Pagamento:Entity<int>
    {
        public decimal Valor { get; set; }
        public virtual MetodoPagamento MetodoPagamento { get; set; }

    }
}
