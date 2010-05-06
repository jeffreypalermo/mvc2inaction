<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<CustomerInfo>" %>
<%@ Import Namespace="ViewModel.Models"%>

<h2>Customer: <%= Html.Encode(Model.Name) %></h2>
<div class="customerdetails">
 <p>Status: <%= Html.Encode(Model.Status) %></p>
 <p>Total Amount Paid: <%= Html.Encode(Model.TotalAmountPaid) %></p>
 <p>Address: <%= Model.ShippingAddress %></p>
</div>
