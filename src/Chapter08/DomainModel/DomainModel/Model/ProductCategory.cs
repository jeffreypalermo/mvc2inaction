namespace DomainModel.Model
{
	public class ProductCategory : Entity
	{
		public string Name { get; set; }
		public ProductCategory ParentCategory { get; set; }

		public ProductCategory SpawnChildCategory(string name)
		{
			return new ProductCategory
			       	{
			       		ParentCategory = this,
			       		Name = name
			       	};
		}
	}
}