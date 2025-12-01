using System.ComponentModel.DataAnnotations;

namespace Api.W.Movies.DAL.Models.Dtos
{
    public class MovieCreateUpdateDto
    {
        [Required(ErrorMessage = "El nombre de la película es obligatorio.")]
        [MaxLength(100, ErrorMessage = "El número máximo de caracteres es de 100.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "La duración es obligatoria.")]
        public int Duration { get; set; }

        [MaxLength(1000, ErrorMessage = "La descripción puede tener máximo 1000 caracteres.")]
        public string? Description { get; set; }

        [Required(ErrorMessage = "La clasificación es obligatoria.")]
        [MaxLength(10, ErrorMessage = "La clasificación puede tener máximo 10 caracteres.")]
        public string Clasification { get; set; }
    }
}
