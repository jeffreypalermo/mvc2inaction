<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="aboutTitle" ContentPlaceHolderID="TitleContent" runat="server">
    Secure Json (Post)
</asp:Content>

<asp:Content ID="aboutContent" ContentPlaceHolderID="MainContent" runat="server">

<script type="text/javascript">

	$.postJSON = function(url, data, callback) {
		$.post(url, data, callback, "json");
	};
	
	$(function() {

		$.postJSON('/post/getsecurejsonpost', function(data) {
			var options = '';
			for (var i = 0; i < data.length; i++) {
				options += '<option value="' + data[i].Id + '">' + data[i].Title + '</option>';
			}
			$('#securepost').html(options);
		});

	});
	
</script>

    <h2>Secure Json (Post)</h2>
    <p>
        The select box is populated with by a post action to Json and is not vulnerable to hijacking.  We did not need to modify the default behavior of JsonResult.
    </p>
     <div>
       <select id="securepost"/>
    </div>
</asp:Content>
