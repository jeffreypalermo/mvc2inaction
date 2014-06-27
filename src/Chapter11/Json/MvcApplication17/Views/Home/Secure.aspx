<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="aboutTitle" ContentPlaceHolderID="TitleContent" runat="server">
    Secure Json
</asp:Content>

<asp:Content ID="aboutContent" ContentPlaceHolderID="MainContent" runat="server">

<script type="text/javascript">
$(function() {
$.getJSON('/post/getsecurejson',
	function(data) {
		var options = '';
		for (var i = 0; i < data.d.length; i++) {
			options += '<option value="' +
			data.d[i].Id + '">' + data.d[i].Title +
			'</option>';
		}
		$('#secure').html(options);
	});
});
</script>
    <h2>Secure Json</h2>
     <div>
     <p>
        The select box is populated with by a get action to Json and is not vulnerable to hijacking because the resulting Json is not an array.  We used a special ActionResult that we created, SecureJsonResult, to ensure this behavior.
    </p>
       <select id="secure"/>
    </div>
</asp:Content>
