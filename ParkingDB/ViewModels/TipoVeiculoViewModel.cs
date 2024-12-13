namespace ParkingDB.ViewModels
{
    public class TipoVeiculoRequestViewModel
    {
        public string Descricao { get; set; }
    }

    public class TipoVeiculoResponseViewModel
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
    }
}
