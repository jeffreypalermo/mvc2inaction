<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<Profile>>" %>
<%@ Import Namespace="AccountProfile.Models"%>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Profiles
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

	<% Html.RenderPartial("SearchForm", new ProfileSearchCriteria()); %>

	<% Html.RenderPartial("Profiles", Model); %>
	
</asp:Content>
