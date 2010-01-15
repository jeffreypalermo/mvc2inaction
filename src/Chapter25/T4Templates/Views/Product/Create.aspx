<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master"
    Inherits="System.Web.Mvc.ViewPage<T4Templates.Models.Product>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Create
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        Create</h2>
    <%= Html.ValidationSummary("Create was unsuccessful. Please correct the errors and try again.") %>
    <% using (Html.BeginForm())
       {%>
    <fieldset>
        <legend>Fields</legend>
        <p>
            <label for="Id">
                Id:</label>
            <%= Html.TextBox("Id") %>
            <%= Html.ValidationMessage("Id", "*") %>
        </p>
        <p>
            <label for="Name">
                Name:</label>
            <%= Html.TextBox("Name") %>
            <%= Html.ValidationMessage("Name", "*") %>
        </p>
        <p>
            <label for="Description">
                Description:</label>
            <%= Html.TextBox("Description") %>
            <%= Html.ValidationMessage("Description", "*") %>
        </p>
        <p>
            <label for="ActiveDate">
                ActiveDate:</label>
            <%= Html.TextBox("ActiveDate") %>
            <%= Html.ValidationMessage("ActiveDate", "*") %>
        </p>
        <p>
            <label for="RetireDate">
                RetireDate:</label>
            <%= Html.TextBox("RetireDate") %>
            <%= Html.ValidationMessage("RetireDate", "*") %>
        </p>
        <p>
            <input type="submit" value="Create" />
        </p>
    </fieldset>
    <% } %>
    <div>
        <%=Html.ActionLink("Back to List", "Index") %>
    </div>
</asp:Content>
