namespace CustomActionResults.Controllers 
{
	using System.Collections;
	using System.Web.Mvc;

	public class CsvActionResult : ActionResult 
	{
		public IEnumerable ModelListing { get; set; }

		public CsvActionResult(IEnumerable modelListing)
		{
			ModelListing = modelListing;
		}

		public override void ExecuteResult(ControllerContext context) 
		{
			byte[] data = new CsvFileCreator().AsBytes(ModelListing);
			
			var fileResult = new FileContentResult(data, "text/csv") 
			{
				FileDownloadName = "CsvFile.csv"
			};

			fileResult.ExecuteResult(context);
		}
	}
}