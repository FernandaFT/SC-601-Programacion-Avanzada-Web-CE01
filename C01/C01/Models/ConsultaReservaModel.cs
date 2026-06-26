namespace C01.Models
{
    public class ConsultaReservaModel
    {
        public DateTime FechaReserva { get; set; }
        public decimal MontoTotal { get; set; }
        public string DescripcionTipo { get; set; } = string.Empty;
        public string NumeroHabitacion { get; set; } = string.Empty;
    }
}
