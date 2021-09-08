using ApiAuthor.Validations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ApiAuthor.Entities
{
    public class Author
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "El Campo {0} es requerido")]
        [StringLength(maximumLength: 4, ErrorMessage = "El Campo {0} no debe tener mas de {1} carácteres")]
        [FirstCapitalLetter]
        public string Name { get; set; }
        [Range(18, 120)]
        [NotMapped]
        public int Age { get; set; }
        [CreditCard]
        [NotMapped]
        public string CredicardNumber{ get; set; }
        [Url]
        [NotMapped]
        public string Site { get; set; }
        public virtual List<Book> Books { get; set; }
    }
}
