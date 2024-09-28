<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminAddProduct.aspx.cs" Inherits="Vogue.AdminAddProduct" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Vogue</title>
    <!-- Customized Bootstrap Stylesheet -->
    <link href="css/style.css" rel="stylesheet"/>

    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table class="auto-style1">
                <tr>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>Product Name</td>
                    <td>
                        <asp:TextBox ID="pname" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>Description</td>
                    <td>
                        <asp:TextBox ID="description" runat="server" Height="101px" TextMode="MultiLine" Width="272px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>Price</td>
                    <td>
                        <asp:TextBox ID="price" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>Stock</td>
                    <td>
                        <asp:TextBox ID="stock" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>Category</td>
                    <td>
                        <asp:DropDownList ID="DropDownList1" runat="server">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>Image</td>
                    <td>
                        <asp:FileUpload ID="FileUpload1" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td>
                        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Insert" />
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
