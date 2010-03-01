namespace Core.Domain
{
   public class Customer : Entity
   {
      public string Name { get; set; }
      public string EmailAddress { get; set; }
      public string PhoneNumber { get; set; }
   }
}