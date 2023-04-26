using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace Vectra.Avaliacao.Commons.Entities
{
    public class BaseEntity<T>
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("ID")]
        [Required]
        public T Id { get; protected set; }
        [Column("UPDATED_AT")]
        [Required]
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
        [Column("CREATED_AT")]
        [Required]
        public DateTime CreatedAt { get; set; }

        [Column("IS_ACTIVE")]
        [Required]
        public bool IsActive { get; set; }
    }
}
