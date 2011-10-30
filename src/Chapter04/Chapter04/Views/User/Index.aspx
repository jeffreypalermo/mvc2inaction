<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<IEnumerable<MvcApplication1.Controllers.UserDisplay>>" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Index</title>
</head>
<body>
    <table>
        <tr>
            <th></th>
            <th>
                Username
            </th>
        </tr>

    <% foreach (var item in Model) { %>

        <tr>
            <td>
                <%= Html.Encode(item.Username) %>
            </td>
        </tr>

    <% } %>

    </table>
</body>
</html>

