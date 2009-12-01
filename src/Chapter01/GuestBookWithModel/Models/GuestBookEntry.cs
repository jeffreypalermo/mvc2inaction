using System.ComponentModel.DataAnnotations;

namespace GuestBookWithModel.Models
{
    public class GuestBookEntry
    {
        [Required]
        public string Name { get; set; }

        [Required]        
        [RegularExpression(@"\b[A-Z0-9._%+-]+@[A-Z0-9.-]+\.[A-Z]{2,4}\b", ErrorMessage = "Please enter a valid email address.")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required, StringLength(30), DataType(DataType.MultilineText)]
        public string Comments { get; set; }
    }
}
