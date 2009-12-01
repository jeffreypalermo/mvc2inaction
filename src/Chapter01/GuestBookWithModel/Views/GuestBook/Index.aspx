<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<GuestBookWithModel.Models.GuestBookEntry>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Index
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Index</h2>
    
    <% Html.EnableClientValidation(); %>

<%--    <% using (Html.BeginForm()) {%>--%>
<%----%>
<%--        <fieldset>--%>
<%--            <legend>Fields</legend>--%>
<%--            <p>--%>
<%--                <%= Html.LabelFor(model => model.Name) %>--%>
<%--                <%= Html.TextBoxFor(model => model.Name) %>--%>
<%--                <%= Html.ValidationMessageFor(model => model.Name) %>--%>
<%--            </p>--%>
<%--            <p>--%>
<%--                <%= Html.LabelFor(model => model.Email) %>--%>
<%--                <%= Html.TextBoxFor(model => model.Email) %>--%>
<%--                <%= Html.ValidationMessageFor(model => model.Email) %>--%>
<%--            </p>--%>
<%--            <p>--%>
<%--                <%= Html.LabelFor(model => model.Comments) %>--%>
<%--                <%= Html.TextBoxFor(model => model.Comments) %>--%>
<%--                <%= Html.ValidationMessageFor(model => model.Comments) %>--%>
<%--            </p>--%>
<%--            <p>--%>
<%--                <input type="submit" value="Create" />--%>
<%--            </p>--%>
<%--        </fieldset>--%>
<%----%>
<%--    <% } %>--%>
    
    <h2>Using EditorFor </h2>
    <% using (Html.BeginForm()) {%>

        <fieldset>
            <legend>Fields</legend>
            
            <%= Html.EditorForModel() %>
        
            <p>
                <input type="submit" value="Create" />
            </p>
        </fieldset>

    <% } %>

    <div>
        <%=Html.ActionLink("Back to List", "Index") %>
    </div>

</asp:Content>

