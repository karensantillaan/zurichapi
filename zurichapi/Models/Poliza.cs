using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using zurichapi.Models.Enums;

namespace zurichapi.Models
{
    public class Poliza
    {
        public int Id { get; set; }

        [Required]
        [RegularExpression(@"^\d{10}$", ErrorMessage = "El número de póliza debe tener exactamente 10 dígitos.")]
        public required string NumeroPoliza { get; set; }

        [Required]
        [EnumDataType(typeof(TipoPoliza), ErrorMessage = "El tipo de póliza debe ser 'Vida', 'Automóvil', 'Salud' o 'Hogar'.")]
        public TipoPoliza TipoPoliza { get; set; }

        [Required]
        public required DateTime FechaInicio { get; set; }

        [Required]
        public required DateTime FechaExpiracion { get; set; }

        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage = "El monto asegurado debe ser positivo.")]
        public decimal MontoAsegurado { get; set; }

        [Required]
        [EnumDataType(typeof(EstadoPoliza), ErrorMessage = "El estado debe ser 'Activa' o 'Cancelada'.")]
        public EstadoPoliza Estado { get; set; }

        // Relación con Cliente
        [Required]
        public int ClienteId { get; set; }
        [ForeignKey("ClienteId")]
        public required Cliente Cliente { get; set; }
    }
}
