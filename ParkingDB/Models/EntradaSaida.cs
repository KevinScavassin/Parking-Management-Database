namespace ParkingDB.Models
{
    public class EntradaSaida
    {
        public int IDEntradaSaida { get; set; }
        public int IDVaga { get; set; }
        public int IDVeiculo { get; set; }
        public DateTime DataHoraEntrada { get; set; }
        public DateTime? DataHoraSaida { get; set; }
        public DateTime DataHoraInclusão { get; set; }
        public string UsuarioInclusao { get; set; }
        public DateTime DataHoraAlteracao { get; set; }
        public string UsuarioAlteracao { get; set; }
        public Boolean IsActive { get; set; }
    }
}
