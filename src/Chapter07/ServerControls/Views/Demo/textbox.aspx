<%@ Page Language="C#" AutoEventWireup="true" Inherits="System.Web.Mvc.ViewPage" MasterPageFile="~/Views/Demo/ServerControls.Master"%>

<asp:Content ID="head" runat="server" ContentPlaceHolderID="headContent">
    <script language="C#" runat="server">
        public override void VerifyRenderingInServerForm(Control control)
        {
        }
    </script>
</asp:Content>

<asp:Content ID="content" runat="server" ContentPlaceHolderID="MainContent">
    <!-- Figure 8.1 (run) -->

    <form id="Form1" runat="server">
    The text box:
    <asp:TextBox ID="TextBox1" runat="server" />
    </form>

    <!-- end Figure 8.1 -->
</asp:Content>