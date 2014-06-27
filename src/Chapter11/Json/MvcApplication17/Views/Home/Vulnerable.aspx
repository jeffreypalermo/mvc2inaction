<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="aboutTitle" ContentPlaceHolderID="TitleContent" runat="server">
    Vulnerable Json
</asp:Content>

<asp:Content ID="aboutContent" ContentPlaceHolderID="MainContent" runat="server">

<script type="text/javascript">

	$(function() {

		$.getJSON('/post/getinsecurejson', function(data) {
			var options = '';
			for (var i = 0; i < data.length; i++) {
				options += '<option value="' + data[i].Id + '">' + data[i].Title + '</option>';
			}
			$('#insecure').html(options);
		});

	});

</script>

    <h2>Vulnerable Json</h2>
    <p>
        The select box is populated with Json vulnerable to hijacking.  This is allowed by ASP.NET MVC only because we set JsonRequestBehavior.AllowGet in the JsonResult.
    </p>
     <div>
       <select id="insecure"/>
    </div>
</asp:Content>
