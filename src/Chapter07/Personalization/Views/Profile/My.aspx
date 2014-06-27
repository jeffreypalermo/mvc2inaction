<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" AutoEventWireup="true" Inherits="System.Web.Mvc.ViewPage<ProfileBase>" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <h3>Your Profile:</h3>
    Nick Name: <%= Model["NickName"] %><br />
    Age: <%= Model["Age"] %><br />

    <%= Html.ActionLink("Edit my Profile", "edit") %>

</asp:Content>
