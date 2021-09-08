using ApiAuthor.Validations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ApiAuthor.Entities
{
    public class Author : IValidatableObject
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "El Campo {0} es requerido")]
        [StringLength(maximumLength: 4, ErrorMessage = "El Campo {0} no debe tener mas de {1} carácteres")]
        // [FirstCapitalLetter]
        public string Name { get; set; }

        public virtual List<Book> Books { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (!string.IsNullOrEmpty(Name))
            {
                string firstLetter = Name.ToString()[0].ToString();
                if (firstLetter != firstLetter.ToUpper())
                {
                    yield return new ValidationResult("The first Letter must be Capital", 
                        new String[] { nameof(Name) });
                }

            }
        }
    }
}
