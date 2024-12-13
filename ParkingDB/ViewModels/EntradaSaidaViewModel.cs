namespace ParkingDB.ViewModels
{
    public class EntradaSaidaRequestViewModel
    {
        public DateTime DataHoraEntrada { get; set; }
        public DateTime? DataHoraSaida { get; set; }
        public int VagaId { get; set; }
        public int VeiculoId { get; set; }
        public int ClienteId { get; set; }
        public int PagamentoId { get; set; }
    }

    public class EntradaSaidaResponseViewModel
    {
        public int Id { get; set; }
        public DateTime DataHoraEntrada { get; set; }
        public DateTime? DataHoraSaida { get; set; }
        public int VagaId { get; set; }
        public int VeiculoId { get; set; }
        public int ClienteId { get; set; }
        public int PagamentoId { get; set; }
        public string ClienteNome { get; set; }     
        public decimal PagamentoValor { get; set; } 
        public string VeiculoPlaca { get; set; }    
    }   
}
