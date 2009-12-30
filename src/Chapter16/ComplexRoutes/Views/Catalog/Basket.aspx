<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Basket
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Basket</h2>

    This is your basket!
    
    <p><i>Note that the intended URL is <pre>/basket</pre> NOT <pre>/catalog/basket</pre></i></p>

</asp:Content>
