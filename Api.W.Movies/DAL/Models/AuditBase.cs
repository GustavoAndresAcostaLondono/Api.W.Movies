using System.ComponentModel.DataAnnotations;

namespace Api.W.Movies.DAL.Models
{
    public class AuditBase
    {
        [Key] // Este indica que el campo es la clave primaria
        public virtual int Id { get; set; }

        public virtual DateTime CreatedDate { get; set; }

        public virtual DateTime ModifiedDate { get; set; }
    }
}
