namespace ParkingDB.ViewModels
{
    public class PagamentoRequestViewModel
    {
        public decimal Valor { get; set; }
        public int MetodoPagamentoId { get; set; }  // Id do Método de Pagamento
    }

    public class PagamentoResponseViewModel
    {
        public int Id { get; set; }
        public decimal Valor { get; set; }
        public string MetodoPagamentoDescricao { get; set; }  // Descrição do Método de Pagamento
    }
}
