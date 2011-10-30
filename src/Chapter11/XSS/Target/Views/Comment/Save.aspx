<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<CommentInput>" %>

<%@ Import Namespace="Target.Controllers" %>
<asp:Content ID="indexTitle" ContentPlaceHolderID="TitleContent" runat="server">
	Comment
</asp:Content>
<asp:Content ID="indexContent" ContentPlaceHolderID="MainContent" runat="server">

	<p>Name:</p>

	<p>
		<%= Model.Name %>
	</p>

	<p>&nbsp;</p>

	<p>Comment:</p>

	<p>
		<%= Model.Comment %>
	</p>

</asp:Content>
