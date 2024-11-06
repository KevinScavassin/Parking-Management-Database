namespace ParkingDB.Models
{
    public class MetodoPagamento
    {
        public int IDMetodoPagamento { get; set; }
        public string Descricao { get; set; }
        public ICollection<Pagamento> Pagamentos { get; set; }

    }
}
