using System.ComponentModel.DataAnnotations;

namespace ApiAuthor.Entities
{
    public class Book
    {
        public int Id { get; set; }
        [StringLength(maximumLength: 250, ErrorMessage = "El Campo {0} no debe tener mas de {1} carácteres")]
        public string Title { get; set; }
    }
}
