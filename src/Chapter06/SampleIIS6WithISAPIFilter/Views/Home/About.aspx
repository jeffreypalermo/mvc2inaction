<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>About</title>
</head>
<body>
    <div>
        <h1>IIS6 Hosting Sample</h1>
        <p>Notice how the action is appended after the extension.</p>
        
        <%= Html.ActionLink("Back to Index", "index") %>
    </div>
</body>
</html>
