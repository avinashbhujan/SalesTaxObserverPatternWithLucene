<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Tax.aspx.cs" Inherits="SalesTaxWeb.Tax" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:TextBox ID="txtPath" runat="server"></asp:TextBox>
&nbsp;&nbsp;
        <asp:Button ID="btnUpdate" runat="server" Text="Update" OnClick="Search_Click" />
        <br />
        <asp:Label ID="lblTotalSales" runat="server"></asp:Label><br />
        <asp:Label ID="lblTotalTax" runat="server"></asp:Label><br />
        <asp:Label ID="lblTotalAmount" runat="server"></asp:Label><br />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <a href="Menu.aspx"> Back </a> 
        <br />
    
    </div>
    </form>
</body>
</html>
