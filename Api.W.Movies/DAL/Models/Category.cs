using System.ComponentModel.DataAnnotations;

namespace Api.W.Movies.DAL.Models
{
    public class Category : AuditBase
    {
        [Required] // Indica que el campo es obligatorio o no puede ser nulo
        [Display(Name = "Nombre de la categpría")] // Sirve para personalizar el nombre mostrado en las vistas o mensajes de error
        public string Name { get; set; }
    }
}

/*
 * Categories
 * Id
 * Name
 * CreatedDate
 * ModifiedDate
 */