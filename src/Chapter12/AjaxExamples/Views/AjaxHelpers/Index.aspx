<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<string>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	MVC AJAX Helpers
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="headContent" runat="server">

    <script src="../../Scripts/jquery-1.3.2.js" type="text/javascript"></script>
    <script src="../../Scripts/MicrosoftAjax.js" type="text/javascript"></script>

    <script src="../../Scripts/MicrosoftMvcAjax.js" type="text/javascript"></script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>MVC Ajax Helpers</h2>
      <div style="border: solid 3px tan; background-color: #ffe; padding: 6px; margin: 6px">
        This example shows two of the Ajax helpers that are built-in to the framework.  They use the same basic approach, but 
        the code you write is slightly different.  Peek into the view ASPX to see how it's done.
    </div>
    
    <h3>Ajax.BeginForm</h3>
    
    <h4>Comments</h4>    
    <ul id="comments">        
    </ul>
    
    <% using(Ajax.BeginForm("AddComment", new AjaxOptions
                                            {
                                                HttpMethod = "POST", 
                                                UpdateTargetId = "comments",
                                                InsertionMode = InsertionMode.InsertAfter                                                
                                            })) { %>
    
        <%= Html.TextArea("Comment", new{rows=5, cols=50}) %>
        <button type="submit">Add Comment</button>
                                            
    <% } %>
    
    <h3>Ajax.Link</h3>
    
    <%= Ajax.ActionLink("Show the privacy Policy", "PrivacyPolicy", 
        new AjaxOptions{InsertionMode = InsertionMode.Replace, UpdateTargetId = "privacy"}) %>

    <div id="privacy"></div>
</asp:Content>