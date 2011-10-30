<%@ Page Title="" Language="C#" Inherits="System.Web.Mvc.ViewPage< System.ServiceModel.Syndication.SyndicationFeed>" %>
<ul>
    <%foreach(var item in Model.Items) {%>
        <li><%=item.Title.Text %> - <%=item.Authors[0].Name %></li>
    <%} %>
</ul>