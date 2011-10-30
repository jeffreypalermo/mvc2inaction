<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<Speaker>" %>
<%@ Import Namespace="AjaxExamples.Models"%>
<%@ Import Namespace="Microsoft.Web.Mvc" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Speaker Details
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="headContent" runat="server">
    <style type="text/css">
        .speaker img
        {
        	float: left;
        	margin: 5px;
        }

    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Speaker Details: <%= Model.FullName %></h2>

    <p class="speaker">
        <%= Html.Image(Model.PictureUrl, Model.FullName) %>
        <i><%= Model.Bio %></i>
    </p>

    <br style="clear:both" />
    <%= Html.ActionLink("Back to speakers", "index") %>

</asp:Content>