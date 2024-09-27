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
        <div>
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
        </div>
    </form>
</body>
</html>
