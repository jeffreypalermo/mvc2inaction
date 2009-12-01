<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<GuestBookWithModel.Models.GuestBookEntry>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	ThankYou
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Thank You!</h2>
    
    Thank you for signing our Guest Book.  You entered: <br />
    
    <%= Html.DisplayForModel() %>
        
</asp:Content>

