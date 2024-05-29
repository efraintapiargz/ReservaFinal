using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReservaFinal.Modelos
{
    public class Reserva
    {
        public int ReservaId { get; set; }

        [Required(ErrorMessage = "Debe seleccionar un cliente")]
        public int ClienteId { get; set; }
        public Cliente? Cliente { get; set; }

        [Required(ErrorMessage = "Debe seleccionar una habitación")]
        public int HabitacionId { get; set; }
        public Habitacion? Habitacion { get; set; }

        [Required(ErrorMessage = "La fecha de entrada es requerida")]
        public DateTime FechaEntrada { get; set; }

        [Required(ErrorMessage = "La fecha de salida es requerida")]
        public DateTime FechaSalida { get; set; }
    }
}