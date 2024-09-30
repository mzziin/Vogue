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


        <div class="d-flex container justify-content-center align-items-center min-vh-100">
            <div class="card rounded" style="width:24rem;">
                <div class="card-body">
                    <div class="row my-3 px-4">
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


        <%--<div>
            <div class="login-page">
                <div class="form">
                    <form class="login-form">
                        <asp:Label runat="server" ID="error_msg_for_label" Text="" Visible="false"></asp:Label>
                        <br />
                        <div class="text-left">
                            <label for="fullname" class="m-0">Full Name</label>
                            <asp:TextBox runat="server" CssClass="form-control rounded border-primary" ID="fullname"></asp:TextBox>
                        </div>

                        <div class="text-left">
                            <label for="uname" class="m-0">Username</label>
                            <asp:TextBox runat="server" CssClass="form-control rounded border-primary" ID="uname"></asp:TextBox>
                        </div>
                        
                        <div class="text-left">
                            <label for="email" class="m-0">Email</label>
                            <asp:TextBox TextMode="Email" CssClass="form-control rounded border-primary" runat="server" ID="email"></asp:TextBox>
                        </div>

                        <div class="text-left">
                            <label for="pwd" class="m-0">Password</label>
                            <asp:TextBox TextMode="Password" CssClass="form-control rounded border-primary" runat="server" ID="pwd"></asp:TextBox>
                        </div>

                        <div>
                            <asp:Label runat="server" ID="lbl">Role</asp:Label>
                        </div>
                        <asp:RadioButtonList runat="server" ID="role" RepeatDirection="Horizontal" Height="109px">
                            <asp:ListItem Text="Customer" Value="Customer"></asp:ListItem>
                            <asp:ListItem Text="Vendor" Value="Vendor"></asp:ListItem>
                        </asp:RadioButtonList>

                        <div class="text-left">
                            <label for="phone" class="m-0">Phone</label>
                            <asp:TextBox runat="server" ID="phone" CssClass="form-control rounded border-primary"></asp:TextBox>
                        </div>

                        <div class="text-left">
                            <label for="address" class="m-0">Address</label>
                            <asp:TextBox runat="server" ID="address" CssClass="form-control rounded border-primary" Height="125px" Width="268px"></asp:TextBox>
                        </div>

                        <div class="text-left">
                            <label for="zip" class="m-0">Zip Code</label>
                            <asp:TextBox runat="server" CssClass="form-control rounded border-primary" ID="zip"></asp:TextBox>
                        </div>

                        <asp:Button runat="server" ID="btn1" CssClass="btn btn-primary rounded font-weight-bold" Text="Register" OnClick="btn1_Click" />
                        <asp:Label runat="server" ID="error_msg" Text="" ForeColor="Red" Visible="false"></asp:Label>
                        <p class="message">Have an Account? <a href="Login.aspx">Login</a></p>
                    </form>
                </div>
            </div>
        </div>--%>
    </form>
</body>
</html>
