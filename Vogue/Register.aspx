<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="Vogue.Register" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="UTF-8" />
    <title>Login</title>
    <link rel="stylesheet" href="./style.css" />
    <!-- Customized Bootstrap Stylesheet -->
    <link href="css/style.css" rel="stylesheet"/>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container-fluid mt-3 fixed-top">
            <div class="row pt-3 px-5">
                <a href="Index.aspx" class="text-decoration-none col">
                    <h1 class="m-0 display-5 font-weight-semi-bold">Vogue</h1>
                </a>
            </div>
        </div>

        <div class="d-flex container justify-content-center align-items-center min-vh-100">
            <div class="card rounded" style="width:24rem;">
                <div class="card-body">
                    <div class="row px-4">
                        <h3 class="card-title font-weight-bold">Sign <span class="text-primary">Up</span></h3>
                    </div>

                    <div class="row mb-3 px-4">
                        <asp:TextBox runat="server" placeholder="Full name" CssClass="form-control rounded" BorderColor="LightGray" ID="fullname"></asp:TextBox>
                    </div>
                    
                    <div class="row mb-3 px-4">
                        <asp:TextBox runat="server" TextMode="Email" placeholder="E-mail" CssClass="form-control rounded" BorderColor="LightGray" ID="email"></asp:TextBox>
                    </div>
                    
                    <div class="row mb-3 px-4">
                        <asp:TextBox TextMode="MultiLine" runat="server" placeholder="Address" ID="address" CssClass="form-control rounded" BorderColor="LightGray"></asp:TextBox>
                    </div>

                    <div class="row mb-3 px-4 justify-content-between">
                        <div class="col-6 p-0 pr-1">
                            <asp:TextBox runat="server" TextMode="Phone" placeholder="Phone" ID="phone" CssClass="form-control rounded" BorderColor="LightGray"></asp:TextBox>
                        </div>
                        <div class="col-6 p-0 pl-1">
                            <asp:TextBox runat="server" CssClass="form-control rounded" BorderColor="LightGray" placeholder="Zip code" ID="zip"></asp:TextBox>
                        </div>
                    </div>

                    <div class="row mb-3 px-4">
                        <asp:TextBox runat="server" placeholder="Username" CssClass="form-control rounded" BorderColor="LightGray" ID="uname"></asp:TextBox>
                    </div>

                    <div class="row mb-4 px-4">
                        <asp:TextBox runat="server" TextMode="Password" placeholder="Password" CssClass="form-control rounded" BorderColor="LightGray" ID="pwd"></asp:TextBox>
                    </div>

                    <div class="row justify-content-center mb-3 px-4">
                        <asp:RadioButtonList runat="server" ID="role" RepeatDirection="Horizontal">
                            <asp:ListItem Text="&nbsp;Customer" class="mx-2" Value="Customer"></asp:ListItem>
                            <asp:ListItem Text="&nbsp;Vendor" class="mx-2" Value="Vendor"></asp:ListItem>
                        </asp:RadioButtonList>
                    </div>

                    <div class="row justify-content-center mb-2">
                        <asp:Label runat="server" ID="error_msg" Text="" ForeColor="Red" Visible="false"></asp:Label>
                    </div>

                    <div class="row justify-content-center px-4 mb-3">
                        <asp:Button runat="server" ID="btn1" CssClass="btn btn-primary rounded font-weight-semi-bold form-control" Text="Sign Up" OnClick="btn1_Click" />
                    </div>

                    <div class="text-center">
                        <p class="message">Have an Account? <a href="Login.aspx">Sign In</a></p>
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
