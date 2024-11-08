namespace ParkingDB.Models
{
    public class TipoVeiculo
    {
        public int IDTipoVeiculo { get; set; }
        public string Descricao { get; set; }
        public DateTime DataHoraInclusão { get; set; }
        public string UsuarioInclusao { get; set; }
        public DateTime DataHoraAlteracao { get; set; }
        public string UsuarioAlteracao { get; set; }
        public Boolean IsActive { get; set; }
        public ICollection<Vaga> Vagas { get; set; }
        public ICollection<Veiculo> Veiculos { get; set; }
    }
}
