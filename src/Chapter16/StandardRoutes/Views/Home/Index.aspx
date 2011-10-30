<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="indexTitle" ContentPlaceHolderID="TitleContent" runat="server">
    Home Page
</asp:Content>

<asp:Content ID="indexContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%= Html.Encode(ViewData["Message"]) %></h2>
    <p>
        This sample demonstrates the default routes:
    </p>

    <div style="background-color: #eee; border: solid 1px #ddd; margin: 10px; padding: 10px;">
        <pre>{controller}/{action}/{id}</pre>
        Defaults:
                <ul>
                    <li>Controller:  <b>Home</b></li>
                    <li>Action: <b>Index</b></li>
                    <li>Id: <b>null</b></li>
                </ul>
    </div>

    <p>Because of the route defaults, this page is accessible from any of these URLS:</p>
    <ul>
        <li><pre>/</pre></li>
        <li><pre>/home</pre></li>
        <li><pre>/home/index</pre></li>
    </ul>

</asp:Content>
