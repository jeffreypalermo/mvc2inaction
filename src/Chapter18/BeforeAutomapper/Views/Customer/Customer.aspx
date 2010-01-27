<%@ Page Language="C#" 
Inherits="System.Web.Mvc.ViewPage<Customer>" %>
<%@ Import Namespace="Core.Model"%>

<h2>Customer: <%= Html.Encode(Model.Name.First + " " + 
					Model.Name.Middle + " " + Model.Name.Last) %></h2>
<div class="customerdetails">
 <p>Status: <%= Html.Encode(Model.Status) %></p>
 <p>Total Amount Paid: $ 
	<%= Html.Encode(Model.GetTotalAmountPaid()) %></p>
 <p>Address: <%= Html.Encode(Model.ShippingAddress.Line1) %>, 
	<%= Html.Encode(Model.ShippingAddress.Line2) %>, 
	<%= Html.Encode(Model.ShippingAddress.City) %>, 
	<%= Html.Encode(Model.ShippingAddress.State.DisplayName) %> 
	<%= Html.Encode(Model.ShippingAddress.Zip) %></p>
</div>
