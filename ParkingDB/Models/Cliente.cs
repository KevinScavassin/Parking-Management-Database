namespace ParkingDB.Models
{
    public class Cliente
    {
        public int IDCliente { get; set; }
        public string CPF { get; set; }
        public string CNPJ { get; set; }
        public DateTime DataHoraInclusão { get; set; }
        public string UsuarioInclusao { get; set; } 
        public DateTime DataHoraAlteracao { get; set; }
        public string UsuarioAlteracao { get; set; }
        public Boolean IsActive { get; set; }
        public ICollection<Telefone> Telefones { get; set; }
        public ICollection<Reserva> Reservas { get; set; }
        public ICollection<Pagamento> Pagamentos { get; set; }
        public ICollection<Veiculo> Veiculos { get; set; }

        
    }
}
