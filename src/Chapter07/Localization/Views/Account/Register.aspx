﻿<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="Localization.Views.Account.Register" %>

<asp:Content ID="registerContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Account Creation</h2>
    <p>
        Use the form below to create a new account.
    </p>
    <p>
        Passwords are required to be a minimum of <%=Html.Encode(ViewData["PasswordLength"])%> characters in length.
    </p>
    <%= Html.ValidationSummary() %>

    <% using (Html.BeginForm()) { %>
        <div>
            <table>
                <tr>
                    <td>Username:</td>
                    <td>
                        <%= Html.TextBox("username") %>
                        <%= Html.ValidationMessage("username") %>
                    </td>
                </tr>
                <tr>
                    <td>Email:</td>
                    <td>
                        <%= Html.TextBox("email") %>
                        <%= Html.ValidationMessage("email") %>
                    </td>
                </tr>
                <tr>
                    <td>Password:</td>
                    <td>
                        <%= Html.Password("password") %>
                        <%= Html.ValidationMessage("password") %>
                    </td>
                </tr>
                <tr>
                    <td>Confirm password:</td>
                    <td>
                        <%= Html.Password("confirmPassword") %>
                        <%= Html.ValidationMessage("confirmPassword") %>
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td><input type="submit" value="Register" /></td>
                </tr>
            </table>
        </div>
    <% } %>
</asp:Content>
