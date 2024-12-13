namespace ParkingDB.ViewModels
{
        public class ClienteRequestViewModel
        {
            public string Nome { get; set; }    
            public string? CPF { get; set; }
            public string? CNPJ { get; set; }
        }

        public class ClienteResponseViewModel
        {
            public int Id { get; set; }
            public string Nome { get; set; }
            public string CPF { get; set; }
            public string CNPJ { get; set; }
        }
}
