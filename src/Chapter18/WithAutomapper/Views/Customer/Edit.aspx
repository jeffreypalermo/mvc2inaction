<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<CustomerInput>" %>
<%@ Import Namespace="WithAutomapper.Controllers"%>
<%@ Import Namespace="WithAutomapper.Models"%>

<asp:Content ID="indexTitle" ContentPlaceHolderID="TitleContent" runat="server">
    Home Page
</asp:Content>

<asp:Content ID="indexContent" ContentPlaceHolderID="MainContent" runat="server">

	<div>
		<%= Html.TextBoxFor(x => x.NameFirst) %>
	</div>

	<div>
		<%= Html.TextBoxFor(x => x.NameLast) %>
	</div>

	<div>
		<%= Html.DropDownListFor(x => x.StatusValue, Model.AllStatuses) %>
	</div>

</asp:Content>
