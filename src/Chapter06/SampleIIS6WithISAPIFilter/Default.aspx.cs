using System;
using System.Web.UI;
namespace SampleIIS6WithISAPIFilter
{
	public partial class Default : Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			Response.Redirect("~/home");
		}
	}
}


