<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<AccountProfile.Models.LogOnWidgetModel>" %>

<%
    if (Model.IsAuthenticated) {
%>
        Welcome <strong><%= Html.Encode(Model.Profile.Username) %> (<%= Html.Encode(Model.Profile.Email) %>)</strong>!
        [ <%= Html.ActionLink("Log Off", "LogOff", "Account") %> | <%= Html.ActionLink("Profile", "Show", "Profile",  new RouteValueDictionary(new { username = Html.Encode(Model.Profile.Username) }), null)%> ]
<%
    }
    else {
%>
        [ <%= Html.ActionLink("Log On", "LogOn", "Account") %> ]
<%
    }
%>