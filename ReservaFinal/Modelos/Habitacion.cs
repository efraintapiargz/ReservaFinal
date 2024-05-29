using System.ComponentModel.DataAnnotations;

namespace ReservaFinal.Modelos
{
    public class Habitacion
    {
        public int HabitacionId { get; set; }
        [Required(ErrorMessage = "El tipo de habitación es requerido")]
        [StringLength(100, ErrorMessage = "Máximo 100 caracteres")]
        public string? TipoHabitacion { get; set; }
        [Required(ErrorMessage = "El estado es requerido")]
        [StringLength(100, ErrorMessage = "Máximo 100 caracteres")]

        public string? Estado { get; set; }
        [Required(ErrorMessage = "El precio por noche es requerido")]
        public decimal PrecioNoche { get; set; }
    }
}
