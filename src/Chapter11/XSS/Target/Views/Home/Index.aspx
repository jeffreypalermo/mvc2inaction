<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="indexTitle" ContentPlaceHolderID="TitleContent" runat="server">
    Home Page
</asp:Content>

<asp:Content ID="indexContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%= Html.Encode(ViewData["Message"]) %></h2>
    <p>
        This action has sent a cookie to the client browser.  We'll pretend that the cookie contains sensitive information like an authentication token.
        </P>
        <pre>
public ActionResult Index()
{
	var cookie = new HttpCookie("mvcinaction", "secret");

	Response.SetCookie(cookie);

	return View();
}</pre>
<p>
Now that the cookie is set, we can continue to the <a href="/comment/new">Comments page</a> and attempt an XSS attack.


    </p>
</asp:Content>
