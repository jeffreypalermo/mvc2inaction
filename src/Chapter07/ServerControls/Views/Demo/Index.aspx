<%@ Page Language="C#" AutoEventWireup="true" Inherits="System.Web.Mvc.ViewPage" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>Chapter 8 - Examples </title>
</head>
<body>
    
    <ul>
        <li><%= Html.ActionLink("TextBox", "textbox") %></li>
        <li><%= Html.ActionLink("GridView", "grid") %></li>
        <li><%= Html.ActionLink("Menu", "menu") %></li>
    </ul>   
</body>
</html>
