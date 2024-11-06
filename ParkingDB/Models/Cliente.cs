namespace ParkingDB.Models
{
    public class Cliente
    {
        public int IDCliente { get; set; }
        public string CPF { get; set; }
        public string CNPJ { get; set; }
        public ICollection<Telefone> Telefones { get; set; }
        public ICollection<Reserva> Reservas { get; set; }
        public ICollection<Pagamento> Pagamentos { get; set; }
        public ICollection<Veiculo> Veiculos { get; set; }

        
    }
}
