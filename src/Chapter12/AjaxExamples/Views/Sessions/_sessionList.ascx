<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<IEnumerable<Session>>" %>
<%@ Import Namespace="AjaxExamples.Models"%>

<table id="sessions">
    <tr>
        <th>Title</th>
        <th>Description</th>
        <th>Level</th>
        <th></th>
    </tr>

    <% if(Model.Count() == 0) { %>
    <tr>
        <td colspan="4" align="center">There are no sessions.  Add one below!</td>
    </tr>
    <% } %>

    <% foreach(var session in Model) { %>

    <tr>
        <td><%=session.Title %></td>
        <td><%=session.Description %></td>
        <td><%=session.Level %></td>
        <td>
            <form action='<%= Url.Action("remove", "sessions") %>' method="post">
                <input type="hidden" name="session_id" value='<%= session.Id %>' />
                <input type="submit" value="remove" />
            </form>
        </td>
    </tr>

    <% } %>
</table>