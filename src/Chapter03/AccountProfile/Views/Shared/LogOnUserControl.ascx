<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>
<%@ Import Namespace="AccountProfile.Controllers"%>
<%
    if (Request.IsAuthenticated) {
%>
        Welcome <b><%= Html.Encode(Page.User.Identity.Name) %></b>!
        [ <%= Html.ActionLink("Log Off", "LogOff", "Account") %> | <%= Html.ActionLink("Profile", "Show", "Profile", new RouteValueDictionary(new { username = Html.Encode(Page.User.Identity.Name) }), null)%> ]
<%
    }
    else {
%>
        [ <%= Html.ActionLink("Log On", "LogOn", "Account") %> ]
<%
    }
%>
