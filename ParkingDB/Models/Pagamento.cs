namespace ParkingDB.Models
{
    public class Pagamento
    {
        public int IDPagamento { get; set; }
        public int IDCliente { get; set; }
        public int IDMetodoPagamento { get; set; }
        public int IDEntradaSaida { get; set; }
        public decimal Valor { get; set; }
        public DateTime DataHoraInclusão { get; set; }
        public string UsuarioInclusao { get; set; }
        public DateTime DataHoraAlteracao { get; set; }
        public string UsuarioAlteracao { get; set; }
        public Boolean IsActive { get; set; }
        public EntradaSaida EntradaSaida { get; set; }

    }
}
