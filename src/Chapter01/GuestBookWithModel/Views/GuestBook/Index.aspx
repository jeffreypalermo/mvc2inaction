<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<GuestBookWithModel.Models.GuestBookEntry>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Guest Book
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Sign the Guest Book!</h2>


    <% using (Html.BeginForm()) {%>

        <fieldset>
            <legend>Fields</legend>
            <p>
                <%= Html.LabelFor(model => model.Name) %>
                <%= Html.TextBoxFor(model => model.Name) %>
            </p>
            <p>
                <%= Html.LabelFor(model => model.Email) %>
                <%= Html.TextBoxFor(model => model.Email) %>
            </p>
            <p>
                <%= Html.LabelFor(model => model.Comments) %>
                <%= Html.TextAreaFor(model => model.Comments) %>
            </p>
            <p>
                <input type="submit" value="Create" />
            </p>
        </fieldset>

    <% } %>

</asp:Content>

