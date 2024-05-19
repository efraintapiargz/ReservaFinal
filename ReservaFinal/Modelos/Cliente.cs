using System.ComponentModel.DataAnnotations;

namespace ReservaFinal.Modelos
{
    public class Cliente
    {
        public int ClienteId {  get; set; }
        [Required(ErrorMessage ="El nombre es requerido")]
        [StringLength(100, ErrorMessage = "Máximo 100 caracteres")]
        public string? Nombre { get; set; }
        [Required(ErrorMessage = "El correo es requerido")]
        [EmailAddress(ErrorMessage ="Debe ser un correo válido")]
        [StringLength(100, ErrorMessage = "Máximo 100 caracteres")]

        public string? Correo { get; set; }
        [Required(ErrorMessage = "El teléfono es requerido")]
        [StringLength(100, ErrorMessage = "Máximo 100 caracteres")]
        public string? Telefono { get; set; }
    }
}
