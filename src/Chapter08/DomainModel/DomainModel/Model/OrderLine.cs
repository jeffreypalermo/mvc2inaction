namespace DomainModel.Model
{
	public class OrderLine : Entity
	{
		public Product Product { get; set; }
		public decimal Price { get; set; }
		public int Quantity { get; set; }
	}
}