<%@ Page Language="C#" AutoEventWireup="true" Inherits="System.Web.Mvc.ViewPage<Customer[]>" %>
<%@ Import Namespace="ServerControls.Models"%>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Chapter 8 - GridView Example</title>
</head>
<body>

    <!-- Listing 8.2 -->
    <%
        grid1.DataSource = ViewData.Model;
        grid1.DataBind();
    %>
    <!-- end listing 8.2 -->

    <form runat="server">
    <asp:GridView ID="grid1" runat="server" />
    </form>
</body>
</html>
