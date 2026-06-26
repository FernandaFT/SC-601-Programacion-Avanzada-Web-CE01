using Microsoft.AspNetCore.Mvc.Rendering;

namespace C01.Models
{
    public class ReservaModel
    {
        public string NumeroHabitacion { get; set; } = string.Empty;
        public decimal MontoTotal { get; set; }
        public int? TipoHabitacion { get; set; }
        public List<SelectListItem> TiposHabitaciones { get; set; } = new List<SelectListItem>();
    }
}
