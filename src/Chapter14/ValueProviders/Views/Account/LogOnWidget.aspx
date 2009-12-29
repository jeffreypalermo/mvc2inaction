<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<LogOnWidgetModel>" %>
<%@ Import Namespace="ValueProvidersExample.Models"%>

<%
    if (Model.IsAuthenticated) {
%>
        Welcome <strong><%= Html.Encode(Model.CurrentUser.Username)%> (<%= Html.Encode(Model.CurrentUser.Email)%>)</strong>!
        [ <%= Html.ActionLink("Log Off", "LogOff", "Account") %> | <%= Html.ActionLink("Profile", "Show", "Profile", new RouteValueDictionary(new { username = Html.Encode(Model.CurrentUser.Username) }), null)%> ]
<%
    }
    else {
%> 
        [ <%= Html.ActionLink("Log On", "LogOn", "Account") %> ]
<%
    }
%>