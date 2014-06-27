<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="indexTitle" ContentPlaceHolderID="TitleContent" runat="server">
    Home Page
</asp:Content>

<asp:Content ID="indexContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Click me, I'm free!</h2>
    <p>
       <form method="post" action="http://localhost:8082/home/save">

		 <input id="Name" name="Name" type="hidden" value="gotcha!" />

		 <button type="submit">Free!!</button>

	</form>
    </p>
</asp:Content>
