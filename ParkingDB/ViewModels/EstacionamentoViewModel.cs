namespace ParkingDB.ViewModels
{
        public class EstacionamentoRequestViewModel
        {
            public string Nome { get; set; }
            public int Capacidade { get; set; }
            public int EnderecoId { get; set; }
        }

        public class EstacionamentoResponseViewModel
        {
            public int Id { get; set; }
            public string Nome { get; set; }
            public int Capacidade { get; set; }
            public int EnderecoId { get; set; }
            public string Endereco { get; set; }
        }
}
