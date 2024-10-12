<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ProductDetail.aspx.cs" Inherits="Vogue.ProductDetail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="NavbarContent" runat="server">
    <div class="container-fluid">
        <div class="row border-top px-xl-5">
            
            <div class="col-lg-12">
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
    <!-- Shop Detail Start -->
    <div class="container-fluid pt-5">
        <div class="row px-xl-5">
            <div class="col-lg-4">
                <asp:Image ID="Image1" runat="server" CssClass="w-75" />                
            </div>

            <div class="col-lg-4 pt-5">
                <h3 class="font-weight-semi-bold">
                    <asp:Label runat="server" ID="name"></asp:Label>
                </h3>

                <h3 class="font-weight-semi-bold mb-4">&#x20b9;
                    <asp:Label runat="server" ID="price"></asp:Label>
                </h3>
                <p class="mb-4">
                    <asp:Label runat="server" ID="description"></asp:Label>
                </p>

                <div class="d-flex align-items-center mb-4 pt-2">
                    <div class="h4 pt-2">
                        <i class="fa fa-shopping-cart mr-3"></i>
                    </div>
                    
                    <asp:Label runat="server" ID="productId" Visible="false" Text=""></asp:Label>
                    <asp:Button runat="server" ID="btn" Text="Add to cart" OnClick="btn_Click" class="btn btn-primary px-3" />

                </div>

            </div>
        </div>

    </div>
    <!-- Shop Detail End -->
</asp:Content>
