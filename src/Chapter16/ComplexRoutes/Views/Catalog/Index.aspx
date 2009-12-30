<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<ComplexRoutes.Models.Widget>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Index
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Widgets</h2>

    <table>
        <tr>
            <th>
                Name
            </th>
            <th>
                Code
            </th>
        </tr>

    <% foreach (var item in Model) { %>
    
        <tr>
            <td>
                <%= Html.ActionLink(item.Name, "Show", new{widgetCode=item.Code}) %>                
            </td>
            <td>
                <%= Html.Encode(item.Code) %>
            </td>
        </tr>
    
    <% } %>
    
        <!-- add a fake widget to the list -->
        <tr>
            <td><%= Html.ActionLink("Fake Widget (doesn't exist)", "Show", new{widgetCode="WDG-0005"}) %></td>
            <td>WDG-0005</td>
        </tr>

    </table>
    
</asp:Content>

