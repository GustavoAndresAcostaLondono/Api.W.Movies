using System.ComponentModel.DataAnnotations;

namespace Api.W.Movies.DAL.Models
{
    public class Movie : AuditBase
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        public int Duration { get; set; } // duración en minutos

        public string? Description { get; set; }

        [Required]
        [MaxLength(10)]
        public string Clasification { get; set; }
    }
}
