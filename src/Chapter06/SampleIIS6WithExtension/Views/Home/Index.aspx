<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>IIS6 Hosting Sample</title>
</head>
<body>
    <div>
        <h1>IIS6 Hosting Sample</h1>

        <%= Html.ActionLink("About", "about") %>

        <p>Notice how the extension .mvc is appended to the URL controller section.  This .mvc extension can be anything
        you want, as long as it is wired up to the aspnet_isapi.dll in IIS.</p>
    </div>
</body>
</html>
