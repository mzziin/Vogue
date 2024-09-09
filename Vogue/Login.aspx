<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Vogue.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="UTF-8"/>
    <title>Login</title>
    <link rel="stylesheet" href="./style.css"/>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div class="login-page">
                <div class="form">
                    <form class="login-form">

                        <asp:Label runat="server" ID="uname">Username</asp:Label>
                        <asp:TextBox runat="server" ID="username"></asp:TextBox>

                        <asp:Label runat="server" ID="Label1">Password</asp:Label>
                        <asp:TextBox runat="server" ID="pwd"></asp:TextBox>

                        <asp:Button BackColor="#D19C97" style="cursor:pointer;" runat="server" ID="btn1" Text="Login" Font-Bold="true" OnClick="btn1_Click"/>

                        <asp:Label runat="server" ID="errorMsg" ForeColor="Red" Text="" Visible="false"></asp:Label>
                        <p class="message">Not registered? <a href="Register.aspx">Create an account</a></p>
                    </form>
                </div>
            </div>
        <//div>
    </form>
</body>
</html>
