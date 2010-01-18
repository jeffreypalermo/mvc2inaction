<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>
<% foreach (var prop in ViewData.ModelMetadata.Properties
       .Where(pm => pm.ShowForEdit && !ViewData.TemplateInfo.Visited(pm))) { %>
<div class="editor-field-container">
    <% if (!String.IsNullOrEmpty(Html.Label(prop.PropertyName).ToHtmlString())) { %>
    <div class="editor-label">
        <%= Html.Label(prop.PropertyName) %>:
    </div>
    <% } %>
    <div class="editor-field">
        <%= Html.Editor(prop.PropertyName) %>
        <%= Html.ValidationMessage(prop.PropertyName, "*") %>
    </div>
    <div class="cleaner"></div>
</div>
<% } %>
