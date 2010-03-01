<%@ Page Language="C#" AutoEventWireup="true" Inherits="System.Web.Mvc.ViewPage" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>Chapter 8 - Menu Example</title>
  
</head>
<body>
    
    <!-- Figure 8.1 (run) -->  
    <form runat="server">
    <asp:Menu ID="menu1" runat="server" BackColor="#E3EAEB" 
        DynamicHorizontalOffset="2" Font-Names="Verdana" Font-Size="0.8em" 
        ForeColor="#666666" Orientation="Horizontal" StaticSubMenuIndent="10px">
        <StaticSelectedStyle BackColor="#1C5E55" />
        <StaticMenuItemStyle HorizontalPadding="5px" VerticalPadding="2px" />
        <DynamicHoverStyle BackColor="#666666" ForeColor="White" />
        <DynamicMenuStyle BackColor="#E3EAEB" />
        <DynamicSelectedStyle BackColor="#1C5E55" />
        <DynamicMenuItemStyle HorizontalPadding="5px" VerticalPadding="2px" />
        <StaticHoverStyle BackColor="#666666" ForeColor="White" />
        <Items>
            <asp:MenuItem Text="File">
                <asp:MenuItem Text="New" NavigateUrl="/demo" />
                <asp:MenuItem Text="Open" NavigateUrl="/demo/"/>
                <asp:MenuItem Text="Close" NavigateUrl="/demo/menu"/>
                <asp:MenuItem Text="Exit" NavigateUrl="/demo/"/>
            </asp:MenuItem>
            <asp:MenuItem Text="Edit" NavigateUrl="/demo/menu"/>
            <asp:MenuItem Text="View" NavigateUrl="/demo/"/>
            <asp:MenuItem Text="Help" NavigateUrl="/demo/"/>            
        </Items>
    </asp:Menu>    
    <!-- end Figure 8.1 -->
   </form>
</body>
</html>
