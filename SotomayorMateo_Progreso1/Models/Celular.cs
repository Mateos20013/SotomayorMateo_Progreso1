namespace SotomayorMateo_Progreso1.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Celular
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "El modelo es obligatorio")]
        public string Modelo { get; set; }

        [Range(2000, 2023, ErrorMessage = "El año debe estar entre 2000 y 2023")]
        public int Año { get; set; }

        [Range(100, 2000, ErrorMessage = "El precio debe estar entre 100 y 2000")]
        public decimal Precio { get; set; }

        [Required]
        public bool Disponible { get; set; }

        [ForeignKey("SotomayorId")]
        public int PerezId { get; set; }

        public Sotomayor Propietario { get; set; }
    }

}
