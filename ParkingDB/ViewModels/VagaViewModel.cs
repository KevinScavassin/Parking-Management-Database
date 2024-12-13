namespace ParkingDB.ViewModels
{
    public class VagaRequestViewModel
    {
        public int EstacionamentoId { get; set; }
        public int TipoVeiculoId { get; set; }
        public int StatusVagaId { get; set; }
    }

    public class VagaResponseViewModel
    {
        public int Id { get; set; }
        public string EstacionamentoNome { get; set; }
        public string TipoVeiculoDescricao { get; set; }
        public string StatusVagaDescricao { get; set; }
    }
}
