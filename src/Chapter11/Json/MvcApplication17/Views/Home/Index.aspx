<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="indexTitle" ContentPlaceHolderID="TitleContent" runat="server">
    Home Page
</asp:Content>

<asp:Content ID="indexContent" ContentPlaceHolderID="MainContent" runat="server">
	<script type="text/javascript">
		
		$.postJSON = function(url, data, callback) {
			$.post(url, data, callback, "json");
		};
		
		$(function() {
			$.getJSON('/home/getinsecurejson', function(data) {
				var options = '';
				for (var i = 0; i < data.length; i++) {
					options += '<option value="' + data[i].Id + '">' + data[i].Title + '</option>';
				}
				$('#insecure').html(options);
			});
			
			$.postJSON('/home/getsecurejsonpost', function(data) {
				var options = '';
				for (var i = 0; i < data.length; i++) {
					options += '<option value="' + data[i].Id + '">' + data[i].Title + '</option>';
				}
				$('#securepost').html(options);
			});

			$.getJSON('/home/getsecurejson', function(data) {
				var options = '';
				for (var i = 0; i < data.d.length; i++) {
					options += '<option value="' + data.d[i].Id + '">' + data.d[i].Title + '</option>';
				}
				$('#secure').html(options);
			});

		});
		
	</script>

    <h2><%= Html.Encode(ViewData["Message"]) %></h2>
    <div>
       <select id="insecure"/>
    </div>
    <div>
       <select id="secure"/>
    </div>
    <div>
       <select id="securepost"/>
    </div>
</asp:Content>
