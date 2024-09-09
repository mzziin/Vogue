<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="Vogue.Register" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="UTF-8" />
    <title>Login</title>
    <link rel="stylesheet" href="./style.css" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div class="login-page">
                <div class="form">
                    <form class="login-form">
                        <asp:Label runat="server" ID="error_msg_for_label" Text="" Visible="false"></asp:Label>
                        <br /><br />
                        <asp:Label runat="server" ID="Label2">FullName</asp:Label>
                        <asp:TextBox runat="server" ID="fullname"></asp:TextBox>


                        <asp:Label runat="server" ID="Label4">Username</asp:Label>
                        <asp:TextBox runat="server" ID="uname"></asp:TextBox>

                        <asp:Label runat="server" ID="Label3">Email</asp:Label>
                        <asp:TextBox TextMode="Email" runat="server" ID="email"></asp:TextBox>

                        <asp:Label runat="server" ID="Label1">Password</asp:Label>
                        <asp:TextBox TextMode="Password" runat="server" ID="pwd"></asp:TextBox>

                        <asp:Label runat="server" ID="lbl">Role</asp:Label>
                        <center>
                            <asp:RadioButtonList runat="server" ID="role" RepeatDirection="Horizontal" Height="109px">
                                <asp:ListItem Text="Customer" Value="Customer"></asp:ListItem>
                                <asp:ListItem Text="Vendor" Value="Vendor"></asp:ListItem>
                            </asp:RadioButtonList>
                        </center>

                        <asp:Label runat="server" ID="Label5">Phone</asp:Label>
                        <asp:TextBox runat="server" ID="phone"></asp:TextBox>

                        <asp:Label runat="server" ID="Label6">Address</asp:Label>
                        <asp:TextBox runat="server" ID="address" Height="145px" Width="268px"></asp:TextBox>

                        <asp:Label runat="server" ID="Label7">ZipCode</asp:Label>
                        <asp:TextBox runat="server" ID="zip"></asp:TextBox>


                        <asp:Button runat="server" ID="btn1" style="cursor:pointer;" BackColor="#D19C97" Text="Register" OnClick="btn1_Click" />
                        <asp:Label runat="server" ID="error_msg" Text="" ForeColor="Red" Visible="false"></asp:Label>
                        <p class="message">Have an Account? <a href="Login.aspx">Login</a></p>
                    </form>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
