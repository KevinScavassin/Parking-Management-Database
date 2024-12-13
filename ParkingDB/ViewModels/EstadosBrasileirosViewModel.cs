namespace ParkingDB.ViewModels
{
        public class EstadosBrasileirosRequestViewModel
        {
            public string UF { get; set; }
            public string Nome { get; set; }
        }
        public class EstadosBrasileirosResponseViewModel
        {
            public int Id { get; set; } 
            public string UF { get; set; }
            public string Nome { get; set; }
        }
}
