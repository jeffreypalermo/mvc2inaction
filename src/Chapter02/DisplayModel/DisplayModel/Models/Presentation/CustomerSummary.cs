namespace DisplayModel.Models.Presentation
{
	public class CustomerSummary
	{
		public string Name { get; set; }
		public bool Active { get; set; }
		public string ServiceLevel { get; set; }
		public string OrderCount { get; set;}
		public string MostRecentOrderDate { get; set; }
	}
}