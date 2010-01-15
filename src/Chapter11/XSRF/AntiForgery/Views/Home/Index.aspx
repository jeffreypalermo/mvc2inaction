<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="indexTitle" ContentPlaceHolderID="TitleContent" runat="server">
    Home Page
</asp:Content>

<asp:Content ID="indexContent" ContentPlaceHolderID="MainContent" runat="server">
<form method="post" action="/home/save">
	 <%= Html.AntiForgeryToken() %>
	 <label for="Name">Name:</label>
	 <%= Html.TextBox("Name") %>
	 <button type="submit">Submit</button>
</form>
</asp:Content>
