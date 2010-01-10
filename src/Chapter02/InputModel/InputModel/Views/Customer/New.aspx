<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master"
Inherits="System.Web.Mvc.ViewPage<NewCustomerInput>" %>
<%@ Import Namespace="InputModel.Models"%>

<asp:Content ID="indexContent" ContentPlaceHolderID="MainContent"
 runat="server">
    <h2>New Customer</h2>
    <form action="<%= Url.Action("Save") %>" method="post">
        <fieldset>
            <div>
                <%= Html.LabelFor(x => x.FirstName) %> 
                <%= Html.TextBoxFor(x => x.FirstName) %>
            </div>
            <div>
                <%= Html.LabelFor(x => x.LastName) %> 
                <%= Html.TextBoxFor(x => x.LastName) %>
            </div>
            <div>
                <%= Html.LabelFor(x => x.Active) %> 
                <%= Html.CheckBoxFor(x => x.Active) %></div>
            <div>
            <button name="save">Save</button></div>	
        </fieldset>
    </form>
</asp:Content>

