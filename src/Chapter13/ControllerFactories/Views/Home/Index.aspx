<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="indexTitle" ContentPlaceHolderID="TitleContent" runat="server">
    Home Page
</asp:Content>

<asp:Content ID="indexContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%= Html.Encode(ViewData["Message"]) %></h2>
    <p>
        
        Set Controller Factory to:
        <% using(Html.BeginForm("SetStructureMap", "Home")) { %>
        <button type="submit">StructureMapControllerFactory</button>
        <% } %>
        
        <% using(Html.BeginForm("SetNinject", "Home")) { %>
        <button type="submit">NinjectControllerFactory</button>
        <% } %>
        
        <% using(Html.BeginForm("SetWindsor", "Home")) { %>
        <button type="submit">WindsorControllerFactory</button>
        <% } %>
        
    </p>
</asp:Content>
