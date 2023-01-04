using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace proiect.Models.BaseEntity
{
    public class BaseEntity : IBaseEntity
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public DateTime DateCreated { get; set; } 
        public DateTime? DateModified { get; set; }
    }
}
