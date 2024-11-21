namespace ParkingDB.Entities
{
    public class Cliente:Entity<int>
    {
        public string CPF { get; set; }
        public string CNPJ { get; set; }
        public virtual ICollection<Telefone> Telefones { get; set; }
        public virtual ICollection<Reserva> Reservas { get; set; }
        public virtual ICollection<Veiculo> Veiculos { get; set; }

    }
}
