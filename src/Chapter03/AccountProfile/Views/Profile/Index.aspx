<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<AccountProfile.Models.Profile[]>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Profiles
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Profiles</h2>
    <table>
        <tr>
            <th>Username</th>
            <th>First name</th>
            <th>Last name</th>
            <th>Email</th>
        </tr>
        <% foreach (var profile in Model) { %>
        <tr>
            <td>
                <%= Html.Encode(profile.Username) %>
            </td>
            <td>
                <%= Html.Encode(profile.FirstName) %>
            </td>
            <td>
                <%= Html.Encode(profile.LastName) %>
            </td>
            <td>
				<%= Html.Encode(profile.Email) %>
            </td>
        </tr>
        <% } %>
    </table>
</asp:Content>
