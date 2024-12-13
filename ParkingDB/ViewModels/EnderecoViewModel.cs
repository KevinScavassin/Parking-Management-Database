namespace ParkingDB.ViewModels
{
        public class EnderecoRequestViewModel
        {
            public string Rua { get; set; }
            public string Numero { get; set; }
            public string Complemento { get; set; }
            public string CEP { get; set; }
            public string Cidade { get; set; }
            public int EstadoId { get; set; } 
        }
        public class EnderecoResponseViewModel
        {
            public int Id { get; set; }
            public string Rua { get; set; }
            public string Numero { get; set; }
            public string Complemento { get; set; }
            public string CEP { get; set; }
            public string Cidade { get; set; }
            public string Estado { get; set; } 
        }
}
    