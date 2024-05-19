using System.ComponentModel.DataAnnotations;

namespace ReservaFinal.Modelos
{
    public class Habitacion
    {
        [Key]
        public int HabitacionId { get; set; }

        [Required]
        public string TipoHabitacion { get; set; }

        [Required]
        public string Estado { get; set; }

        [Required]
        public decimal PrecioNoche { get; set; }
    }
}