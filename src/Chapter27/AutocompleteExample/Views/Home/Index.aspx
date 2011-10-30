<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="indexTitle" ContentPlaceHolderID="TitleContent" runat="server">
    Home Page
</asp:Content>

<asp:Content ID="headContent" ContentPlaceHolderID="HeadContent" runat="server">

    <script src="../../Scripts/jquery-1.4.1.js" type="text/javascript"></script>
    <script src="../../Scripts/jquery.autocomplete.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(function() {
            $("input#city").autocomplete('<%= Url.Action("Find", "Cities") %>');
        });
    </script>

    <style type="text/css">
        div.ac_results ul
        {
    	    margin:0;
    	    padding:0;
    	    background-color: #fff;
    	    list-style-type:none;
    	    border: solid 1px #ccc;
        }

        div.ac_results ul li
        {
    	    font-family: Arial, Verdana, Sans-Serif;
    	    font-size: 12px;
    	    margin: 1px;
    	    padding: 3px;
    	    cursor: pointer;
        }

        div.ac_results ul li.ac_over
        {
    	    background-color: #acf;
        }
    </style>
</asp:Content>

<asp:Content ID="indexContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Cities</h2>
    <p>
        Start typing a city to see the autocomplete behavior in action.
    </p>

    <p>
        <label for="city">City</label>
        <%= Html.TextBox("city") %>
    </p>
</asp:Content>
