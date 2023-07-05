using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApiEntityFramework.Entities
{
    public class Genre: AuditableEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsDeleted { get; set; } 

        public string? test { get; set; }
        public List<Movie> Movies { get; set; }
    }
}
