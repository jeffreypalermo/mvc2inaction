<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<CompanyInput>" %>
<%@ Import Namespace="ModelState.Controllers"%>
<%@ Import Namespace="System.Web.Mvc.Html"%>


<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Edit
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Edit</h2>
    <%Html.BeginForm(); %>
    <%=Html.EditorFor(m=>m) %>
    <button type="submit">Submit</button>
    <%Html.EndForm(); %>
</asp:Content>
