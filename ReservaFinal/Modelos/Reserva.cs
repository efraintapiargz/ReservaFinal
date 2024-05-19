using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReservaFinal.Modelos
{
    public enum EstadoReserva
    {
        Pendiente,
        Confirmada,
        Cancelada
    }
    public class Reserva
    {
        [Key]
        public int ReservaId { get; set; }

        [ForeignKey("Cliente")]
        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; } // Propiedad de navegación

        [Required]
        public DateTime FechaReserva { get; set; }

        [Required]
        public DateTime FechaEntrada { get; set; }

        [Required]
        public DateTime FechaSalida { get; set; }

        [Required]
        public int NumeroHabitaciones { get; set; }

        [Required]
        public EstadoReserva Estado { get; set; }

    }
}