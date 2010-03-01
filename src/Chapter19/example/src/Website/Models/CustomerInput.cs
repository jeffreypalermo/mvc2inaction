using System.ComponentModel;
using System.Web.Mvc;

namespace Website.Models
{
   public class CustomerInput
   {
      [HiddenInput]
      [DisplayName("")]
      public long? Id { get; set; }

      public string Name { get; set; }
      public string EmailAddress { get; set; }
      public string PhoneNumber { get; set; }
   }
}