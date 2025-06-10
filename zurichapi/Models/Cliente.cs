using System.ComponentModel.DataAnnotations;

namespace zurichapi.Models
{
    public class Cliente
    {
        public int Id { get; set; }

        [Required]
        [RegularExpression(@"^\d{10}$", ErrorMessage = "El número de identificación debe tener exactamente 10 dígitos.")]
        public required string NumeroIdentificacion { get; set; }

        [Required]
        [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "El nombre solo puede contener letras y espacios.")]
        [MaxLength(100)]
        public required string NombreCompleto { get; set; }

        [Required]
        [EmailAddress(ErrorMessage = "El correo no es válido.")]
        public required string CorreoElectronico { get; set; }

        [Required]
        [Phone(ErrorMessage = "El teléfono no es válido.")]
        [RegularExpression(@"^\d{10}$", ErrorMessage = "El teléfono debe tener exactamente 10 dígitos.")]
        public required string Telefono { get; set; }

        public required string Direccion { get; set; }

        // Relación con Poliza
        public ICollection<Poliza> Polizas { get; set; } = new List<Poliza>();
    }
}
