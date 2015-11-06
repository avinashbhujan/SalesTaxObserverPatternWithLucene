<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Search.aspx.cs" Inherits="SalesTaxWeb.Search" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        Search Results<br />
        <asp:TextBox ID="txtSearch" runat="server"></asp:TextBox>
&nbsp;
        <asp:Button ID="btnSearch" runat="server" OnClick="btnSearch_Click" Text="Search" />
        <br />
        <asp:Label ID="lblResult" runat="server"></asp:Label>
        <br />
    
        <br />
        <asp:DataList ID="DataList1" runat="server">


            <HeaderTemplate>
                Header

            <table>
                <tr>
                    <th >
                        Identification
                    </th>
                    <th>
                        Product Name
                    </th>
                    <th>
                        Product Origin
                    </th>
                    <th>
                        Product Price
                    </th>
                </tr>
            </HeaderTemplate>

            <ItemTemplate>
                <tr>
                    <td>
                        <%# Eval("ID") %>
                    </td>
                    <td>
                        <%# Eval("Name") %>
                    </td>
                    <td >
                        <%# Eval("Origin") %>
                    </td>
                    <td>
                        <%# Eval("Price") %>
                    </td>
                </tr>
            </ItemTemplate>

            <FooterTemplate>
                </table>
                Footer
            </FooterTemplate>

        </asp:DataList>
        <br />
    
    </div>
    </form>
</body>
</html>
