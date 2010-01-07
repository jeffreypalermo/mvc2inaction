<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="indexTitle" ContentPlaceHolderID="TitleContent" runat="server">
    Home Page
</asp:Content>

<asp:Content ID="indexContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Controller Example</h2>
    <p>
        This example demostrates the following:
        <ul>
        <li><a href="/User/Index">Transforming a domain model to a presentation model in a Controller Action</a></li>
        <li><a href="/User/Display/1">Accepting a <b>value object</b> as a Controller Action parameter</a></li>
        <li><a href="/User/Edit/1">Accepting a <b>complex object</b> as a Controller Action parameter</a></li>
        <li><a href="/User/Edit/2">Applying a storyboard to an Action</a> submit this form while leaving all the fields blank.</li>
        </ul>
    </p>
</asp:Content>
