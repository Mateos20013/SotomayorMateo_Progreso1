namespace SotomayorMateo_Progreso1.Models
{
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Sotomayor
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio")]
        public int Edad { get; set; }

        [Range(0, 100, ErrorMessage = "El valor debe estar entre 0 y 100")]
        public decimal Ingresos { get; set; }

        [StringLength(50, MinimumLength = 2, ErrorMessage = "El nombre debe tener entre 2 y 50 caracteres")]
        public string Nombre { get; set; }

        [Required]
        public bool Activo { get; set; }

        [DataType(DataType.Date)]
        public DateTime FechaNacimiento { get; set; }


        [ForeignKey("CelularId")]
        public Celular Celular { get; set; }
        public int? CelularId { get; set; }
    }

}
