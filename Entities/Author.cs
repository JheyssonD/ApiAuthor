using ApiAuthor.Validations;
using System.ComponentModel.DataAnnotations;

namespace ApiAuthor.Entities
{
    public class Author
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "El Campo {0} es requerido")]
        [StringLength(maximumLength: 120, ErrorMessage = "El Campo {0} no debe tener mas de {1} carácteres")]
        [FirstCapitalLetter]
        public string Name { get; set; }
    }
}
