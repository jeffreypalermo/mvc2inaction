<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<CustomerInfo>" %>
<%@ Import Namespace="WithAutomapper.Models"%>

<h2>Customer: <%= Model.Name %></h2>
<div class="customerdetails">
 <p>Status: <%= Model.Status %></p>
 <p>Total Amount Paid: <%= Model.TotalAmountPaid %></p>
 <p>Address: <%= Model.ShippingAddress %></p>
</div>
