<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Vogue.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="UTF-8"/>
    <title>Login</title>
    <link rel="stylesheet" href="./style.css"/>
    <!-- Customized Bootstrap Stylesheet -->
    <link href="css/style.css" rel="stylesheet"/>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div class="login-page">
                <div class="form">
                    <form class="login-form form">
                        <div class="text-left">
                            <asp:Label runat="server" ID="uname">Username</asp:Label>
                            <asp:TextBox runat="server" CssClass="mt-2 rounded form-control border" ID="username"></asp:TextBox>
                        </div>

                        <div class="text-left mt-2">
                            <asp:Label runat="server" ID="Label1">Password</asp:Label>
                            <asp:TextBox runat="server" CssClass="mt-2 rounded form-control border" TextMode="Password" ID="pwd"></asp:TextBox>
                        </div>
                        
                        <asp:Button BackColor="#D19C97" CssClass="btn rounded btn-primary mt-3 font-weight-bold" runat="server" ID="btn1" Text="Login" OnClick="btn1_Click"/>

                        <asp:Label runat="server" ID="errorMsg" ForeColor="Red" Text="" Visible="false"></asp:Label>
                        <p class="message">Not registered? <a href="Register.aspx">Create an account</a></p>
                    </form>
                </div>
            </div>
        <//div>
    </form>
</body>
</html>
