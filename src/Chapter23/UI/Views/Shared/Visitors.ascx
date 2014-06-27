<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<Visitor[]>" %>
<%@ Import Namespace="Core"%>
<div style="text-align:left">
<h3>Recent Visitors</h3>
	<%foreach (var visitor in ViewData.Model){%>
		<%=visitor.VisitDate%> -
		<%=visitor.IpAddress%> -
		<%=visitor.LoginName%> -
		<%=visitor.PathAndQuerystring%><br />
		<%=visitor.Browser%><hr />
	<%}%>
</div>
