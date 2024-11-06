namespace ParkingDB.Models
{
    public class Pagamento
    {
        public int IDPagamento { get; set; }
        public int IDCliente { get; set; }
        public int IDMetodoPagamento { get; set; }
        public int IDEntradaSaida { get; set; }
        public decimal Valor { get; set; }
        public EntradaSaida EntradaSaida { get; set; }

    }
}
