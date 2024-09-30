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
        <div class="d-flex container justify-content-center align-items-center min-vh-100">
            <div class="card rounded" style="width:24rem;">
                <div class="card-body">
                    <div class="row my-3 px-4">
                        <h3 class="card-title font-weight-bold">Sign <span class="text-primary">In</span></h3>
                    </div>

                    <div class="row mb-3 px-4">
                        <asp:TextBox runat="server" placeholder="Username" CssClass="form-control rounded" BorderColor="LightGray" ID="username"></asp:TextBox>
                    </div>

                    <div class="row mb-3 px-4">
                        <asp:TextBox runat="server" placeholder="Password" TextMode="Password" CssClass="form-control rounded" BorderColor="LightGray" ID="pwd"></asp:TextBox>
                    </div>

                    <div class="row justify-content-center mb-2">
                        <asp:Label runat="server" ID="errorMsg" ForeColor="Red" Text="" Visible="false"></asp:Label>
                    </div>

                    <div class="row justify-content-center px-4 mb-3">
                        <asp:Button runat="server" CssClass="btn btn-primary rounded font-weight-semi-bold form-control" ID="btn1" Text="Sign In" OnClick="btn1_Click" />
                    </div>

                    <div class="text-center">
                        <p class="message">Not registered? <a href="Register.aspx">Sign Up</a></p>
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
