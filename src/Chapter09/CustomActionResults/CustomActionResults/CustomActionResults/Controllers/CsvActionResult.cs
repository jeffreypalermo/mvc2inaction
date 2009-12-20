using System.Collections;
using System.Web.Mvc;

namespace CustomActionResults.Controllers
{
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
            new FileContentResult(data, "text/csv").ExecuteResult(context);            
        }
    }
}