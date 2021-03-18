using System.ComponentModel.DataAnnotations;

namespace Bookstore.Lib.Entities.Base
{
    public abstract class NamedEntity : Entity
    {
        [Required]
        public string Name { get; set; }
    }
}
