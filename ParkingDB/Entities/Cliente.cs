namespace ParkingDB.Entities
{
    public class Cliente:Entity<int>
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
