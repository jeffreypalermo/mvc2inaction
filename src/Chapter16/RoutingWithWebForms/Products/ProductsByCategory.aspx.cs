using System;
using System.Web.UI;

namespace RoutingWithWebForms.Products
{
    public partial class ProductsByCategory : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblCategoryId.Text = Request.QueryString["category"];
        }
    }
}
