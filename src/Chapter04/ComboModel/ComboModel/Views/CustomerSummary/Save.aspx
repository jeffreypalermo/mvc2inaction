<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<CustomerSummaryInput>>" %>
<%@ Import Namespace="ComboModel.Models"%>

<asp:Content ID="Title" ContentPlaceHolderID="TitleContent" runat="server">
   Saved Customers
</asp:Content>

<asp:Content ID="Content" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Saved Customers</h2>
    
    <% foreach (var input in Model) { %>
		<div>
			Customer number <%= input.Number %> is <%= input.Active? "Active" : "Inactive" %>
		</div>
    <% } %>
</asp:Content>