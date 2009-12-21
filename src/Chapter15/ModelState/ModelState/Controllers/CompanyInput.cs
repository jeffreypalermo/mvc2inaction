using System.ComponentModel.DataAnnotations;

namespace ModelState.Controllers
{
    public class CompanyInput
    {
        [Required]
        public string CompanyName { get; set; }

        [DataType(DataType.EmailAddress)]
        public string EmailAddress { get; set; }
    }
}