<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Checkout.aspx.cs" Inherits="Vogue.Checkout" %>

<asp:Content ID="Content1" ContentPlaceHolderID="NavbarContent" runat="server">
    <div class="container-fluid">
        <div class="row border-top px-xl-5">
            <div class="col-lg-9">
                <nav class="navbar navbar-expand-lg bg-light navbar-light py-3 py-lg-0 px-0">
                    <a href="" class="text-decoration-none d-block d-lg-none">
                        <h1 class="m-0 display-5 font-weight-semi-bold">Vogue</h1>
                    </a>
                    <button type="button" class="navbar-toggler" data-toggle="collapse" data-target="#navbarCollapse">
                        <span class="navbar-toggler-icon"></span>
                    </button>
                    <div class="collapse navbar-collapse justify-content-between" id="navbarCollapse">
                        <div class="navbar-nav mr-auto py-0">
                            <a href="index.aspx" class="nav-item nav-link">Home</a>
                            <a href="shop.aspx" class="nav-item nav-link">Shop</a>
                            <a href="contact.aspx" class="nav-item nav-link">Contact</a>
                        </div>
                        <div class="navbar-nav ml-auto py-0">
                            <a href="Login.aspx" class="nav-item nav-link">
                                <asp:Label runat="server" ID="loginlabel">Login</asp:Label>
                            </a>
                            <a href="Register.aspx" class="nav-item nav-link">
                                <asp:Label runat="server" ID="registerlabel">Register</asp:Label>
                            </a>
                        </div>
                    </div>
                </nav>
            </div>
        </div>
    </div>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <!-- Page Header Start -->
    <div class="container-fluid my-3">
        <div class="d-flex flex-column align-items-start justify-content-center ml-5" style="min-height: 200px">
            <h1 class="font-weight-semi-bold text-uppercase mb-3">Checkout</h1>
            <div class="d-inline-flex">
                <p class="m-0"><a href="">Home</a></p>
                <p class="m-0 px-2">-</p>
                <p class="m-0">Checkout</p>
            </div>
        </div>
    </div>
    <!-- Page Header End -->

    <div class="container-fluid pt-2">
        <div class="row px-xl-5">
            <div class="col-lg-8">
                <div class="mb-4">
                    <h4 class="font-weight-semi-bold mb-4">Billing Address</h4>
                    <div class="row">
                        <div class="col-md-6 form-group">
                            <label>First Name</label>
                            <asp:TextBox runat="server" ID="fname" CssClass="form-control" ></asp:TextBox>
                            
                        </div>
                        <div class="col-md-6 form-group">
                            <label>Last Name</label>
                            <asp:TextBox runat="server" ID="lname" CssClass="form-control" ></asp:TextBox>
                            
                        </div>
                        <div class="col-md-6 form-group">
                            <label>E-mail</label>
                            <asp:TextBox runat="server" ID="email" TextMode="Email" CssClass="form-control" ></asp:TextBox>
                            
                        </div>
                        <div class="col-md-6 form-group">
                            <label>Mobile No</label>
                            <asp:TextBox runat="server" ID="phone" TextMode="Phone" CssClass="form-control" ></asp:TextBox>
                            
                        </div>
                        <div class="col-md-6 form-group">
                            <label>Address Line 1</label>
                            <asp:TextBox runat="server" ID="address1" CssClass="form-control" ></asp:TextBox>
                            
                        </div>
                        <div class="col-md-6 form-group">
                            <label>Address Line 2</label>
                            <asp:TextBox runat="server" ID="address2" CssClass="form-control" ></asp:TextBox>
                            
                        </div>
                        <div class="col-md-6 form-group">
                            <label>Country</label>
                            <asp:DropDownList runat="server" ID="country" CssClass="custom-select">
                                <asp:ListItem Text="United States" Value="Unites States"></asp:ListItem>
                                <asp:ListItem Text="India" Value="India"></asp:ListItem>
                                <asp:ListItem Text="Albenia" Value="Albenia"></asp:ListItem>
                            </asp:DropDownList>
                           
                        </div>
                        <div class="col-md-6 form-group">
                            <label>City</label>
                            <asp:TextBox runat="server" ID="city" CssClass="form-control" ></asp:TextBox>
                            
                        </div>
                        <div class="col-md-6 form-group">
                            <label>State</label>
                            <asp:TextBox runat="server" ID="state" CssClass="form-control" ></asp:TextBox>
                            
                        </div>
                        <div class="col-md-6 form-group">
                            <label>ZIP Code</label>
                            <asp:TextBox runat="server" ID="zipcode" CssClass="form-control" ></asp:TextBox>
                            
                        </div>
                    </div>
                </div>
            </div>
            <div class="col-lg-4">
                
                <div class="card border-secondary mb-5">
                    <div class="card-header bg-secondary border-0">
                        <h4 class="font-weight-semi-bold m-0">Payment</h4>
                    </div>
                    <div class="card-body">

                            <asp:RadioButtonList runat="server" ID="payment" CssClass="custom-control">
                                <Items>
                                    <asp:ListItem Text="RazorPay" CssClass="mr-5" Value="RazorPay" />
                                    <asp:ListItem Text="Cash on Delivery" Value="COD" />
                                </Items>
                            </asp:RadioButtonList>


                        <%--<div class="form-group">
                            <div class="custom-control custom-radio">
                                <asp:RadioButton runat="server" CssClass="custom-control-input" ID="razor" GroupName="paymentmethod" />
                                <label for="razor" class="custom-control-label">RazorPay</label>
                            </div>
                        </div>
                        <div class="">
                            <div class="custom-control custom-radio">
                                <asp:RadioButton runat="server" CssClass="custom-control-input" ID="cod" GroupName="paymentmethod"/>
                                <label for="cod" class="custom-control-label">Cash on delivery</label>
                            </div>
                        </div>--%>
                    </div>
                    <div class="card-footer border-secondary bg-transparent">
                        <asp:Button runat="server" ID="orderbtn" CssClass="btn btn-lg btn-block btn-primary font-weight-bold my-3 py-3" Text="Place Order" OnClick="orderbtn_Click"/>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <!-- Checkout End -->

</asp:Content>
