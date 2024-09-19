<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="shop.aspx.cs" Inherits="Vogue.shop" %>

<asp:Content ID="Content1" ContentPlaceHolderID="NavbarContent" runat="server">
    <div class="container-fluid">
                    <div class="row border-top px-xl-5">
                        <div class="col-lg-3 d-none d-lg-block">
                            <a class="btn shadow-none d-flex align-items-center justify-content-between bg-primary text-white w-100" data-toggle="collapse" href="#navbar-vertical" style="height: 65px; margin-top: -1px; padding: 0 30px;">
                                <h6 class="m-0">Categories</h6>
                                <i class="fa fa-angle-down text-dark"></i>
                            </a>
                            <nav class="collapse position-absolute navbar navbar-vertical navbar-light align-items-start p-0 border border-top-0 border-bottom-0 bg-light" id="navbar-vertical" style="width: calc(100% - 30px); z-index: 1;">
                                <div class="navbar-nav w-100 overflow-hidden">

                                    <asp:Repeater ID="repeat_category" runat="server">
                            <ItemTemplate>

                                <a href="shop.aspx?CategoryId=<%# Eval("CategoryId") %>" class="nav-item nav-link" ID="category_name"><%# Eval("CategoryName") %></a>

                            </ItemTemplate>
                        </asp:Repeater>
                                </div>
                            </nav>
                        </div>
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
            <h1 class="font-weight-semi-bold text-uppercase mb-3">Our Shop</h1>
            <div class="d-inline-flex">
                <p class="m-0"><a href="index.aspx">Home</a></p>
                <p class="m-0 px-2">-</p>
                <p class="m-0">Shop</p>
            </div>
        </div>
    </div>
    <!-- Page Header End -->
    
    <!-- Shop Start -->
    <div class="container-fluid pt-2">
        <div class="row px-xl-5">
            <!-- Shop Product Start -->
            <div class="col col-md-12">
                <div class="row pb-3">
                    <asp:Repeater ID="repeat_product" runat="server">
                        <ItemTemplate>
                            <div class="col-lg-3 col-md-6 col-sm-12 pb-1">
                                <div class="card product-item border-0 mb-4">
                                    <div class="card-header product-img position-relative overflow-hidden bg-transparent border p-0">
                                        <asp:Image ID="Image1" CssClass="img-fluid" style="width:100%; height:300px; object-fit:cover;" runat="server" ImageUrl='<%# Eval("ImageUrl") %>' />
                                        <%--<img class="img-fluid w-100" src='<%# Eval("ImageUrl") %>' alt="">--%>
                                    </div>
                                    <div class="card-body border-left border-right text-center p-0 pt-4 pb-3">
                                        <h6 class="text-truncate mb-3">
                                            <asp:Label runat="server" ID="name" Text='<%# Eval("Name") %>'></asp:Label>
                                        </h6>
                                        <div class="d-flex justify-content-center">
                                            <h6>&#x20b9;
                                                <asp:Label runat="server" ID="price" Text='<%# Eval("Price") %>'></asp:Label>
                                            </h6>
                                        </div>
                                    </div>
                                    <div class="card-footer d-flex justify-content-between bg-light border">
                                        <a href="ProductDetail.aspx?ProductId=<%# Eval("ProductId") %>" class="btn btn-sm text-dark p-0"><i class="fas fa-eye text-primary mr-1"></i>View Detail</a>
                                       
                                    </div>
                                </div>
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>

                </div>
            </div>
            <!-- Shop Product End -->
        </div>
    </div>
    <!-- Shop End -->

</asp:Content>
