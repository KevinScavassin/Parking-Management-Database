namespace ParkingDB.Models
{
    public class MetodoPagamento
    {
        public int IDMetodoPagamento { get; set; }
        public string Descricao { get; set; }
        public DateTime DataHoraInclusão { get; set; }
        public string UsuarioInclusao { get; set; }
        public DateTime DataHoraAlteracao { get; set; }
        public string UsuarioAlteracao { get; set; }
        public Boolean IsActive { get; set; }
        public ICollection<Pagamento> Pagamentos { get; set; }

    }
}
