<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<CustomerInfo>>" %>
<%@ Import Namespace="WithAutomapper.Models"%>

<asp:Content ID="indexTitle" ContentPlaceHolderID="TitleContent" runat="server">
    Home Page
</asp:Content>

<asp:Content ID="indexContent" ContentPlaceHolderID="MainContent" runat="server">
<style type="text/css">
.fl 
{
	float: left;
}
</style>
<% foreach (var customer in Model) { %>

<div>
<div class="fl">
<% Html.RenderPartial("Customer", customer); %>
</div>

<div class="fl">
<h2><a href="<%= Url.Action("Show", "Customer", new {id = customer.Id}) %>">[details]</a></h2>
</div>

</div>
<div class="clear"></div>

<% } %>

</asp:Content>
