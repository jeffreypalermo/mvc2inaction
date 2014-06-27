<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Simple ASP.NET MVC Ajax Example w/ jQuery
</asp:Content>


<asp:Content ID="Content3" ContentPlaceHolderID="headContent" runat="server">


    <script src="../../Scripts/jquery-1.3.2.js" type="text/javascript"></script>

    <script type="text/javascript">
        function getMessage() {
            $.get("/SimpleAjax/GetMessage", function(data) {
                $("#result").html(data);
            });
        }
    </script>

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Simple Ajax with ASP.NET MVC and jQuery</h2>

    <p>This example shows how an action can be accessed via Ajax and return raw content.  It also references jquery-1.3.2.js (included in all ASP.NET MVC projects)
    in order to make the javascript much cleaner.</p>

    <p><strong>Click the button to get the message: </strong>
        <button type="button" onclick="getMessage();">Get the Message!</button>
    </p>

    <div id="result"></div>

</asp:Content>
