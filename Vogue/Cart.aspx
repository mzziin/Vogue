<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Cart.aspx.cs" Inherits="Vogue.Cart" %>

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

                                    <a href="" class="nav-item nav-link">Shirts</a>
                                    <a href="" class="nav-item nav-link">Jeans</a>
                                    <a href="" class="nav-item nav-link">Tshirt</a>
                                    <a href="" class="nav-item nav-link">Pants</a>
                                    <a href="" class="nav-item nav-link">Jackets</a>
                                    <a href="" class="nav-item nav-link">Shoes</a>
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
        <div class="d-flex flex-column align-items-start justify-content-center ml-5" style="min-height: 300px">
            <h1 class="font-weight-semi-bold text-uppercase mb-3">Shopping Cart</h1>
            <div class="d-inline-flex">
                <p class="m-0"><a href="index.aspx">Home</a></p>
                <p class="m-0 px-2">-</p>
                <p class="m-0">Shopping Cart</p>
            </div>
        </div>
    </div>
    <!-- Page Header End -->

    <div class="container-fluid pt-2">
        <div class="row px-xl-5">
            <div class="col-lg-8 table-responsive mb-5">
                <table class="table table-bordered text-center mb-0">
                    <thead class="bg-secondary text-dark">
                        <tr>
                            <th>Products</th>
                            <th>Price</th>
                            <th>Quantity</th>
                            <th>Total</th>
                            <th>Remove</th>
                        </tr>
                    </thead>
                    <tbody class="align-middle">

                        <asp:Repeater ID="repeat_cart_product" runat="server">
                        <ItemTemplate>
                        <tr>
                            <td class="align-middle"><img src="img/product-5.jpg" alt="" style="width: 50px;"> 
                                <asp:Label runat="server" ID="name" Text="<%# Eval("name") %>"></asp:Label>
                            </td>
                            <td class="align-middle">
                                <asp:Label runat="server" ID="Label1" Text="<%# Eval("price") %>"></asp:Label>
                            </td>
                            <td class="align-middle">
                                <div class="input-group quantity mx-auto" style="width: 100px;">
                                    <div class="input-group-btn">
                                        <button class="btn btn-sm btn-primary btn-minus" >
                                        <i class="fa fa-minus"></i>
                                        </button>
                                    </div>
                                    <input type="text" class="form-control form-control-sm bg-secondary text-center" value="1">
                                    <div class="input-group-btn">
                                        <button class="btn btn-sm btn-primary btn-plus">
                                            <i class="fa fa-plus"></i>
                                        </button>
                                    </div>
                                </div>
                            </td>
                            <td class="align-middle">$150</td>
                            <td class="align-middle"><button class="btn btn-sm btn-primary"><i class="fa fa-times"></i></button></td>
                        </tr>
                        </ItemTemplate>
                    </asp:Repeater>

                    </tbody>
                </table>
            </div>
            <div class="col-lg-4">
                
                <div class="card border-secondary mb-5">
                    <div class="card-header bg-secondary border-0">
                        <h4 class="font-weight-semi-bold m-0">Cart Summary</h4>
                    </div>
                    <div class="card-body">
                        <div class="d-flex justify-content-between mb-3 pt-1">
                            <h6 class="font-weight-medium">Subtotal</h6>
                            <h6 class="font-weight-medium">$150</h6>
                        </div>
                        <div class="d-flex justify-content-between">
                            <h6 class="font-weight-medium">Shipping</h6>
                            <h6 class="font-weight-medium">$10</h6>
                        </div>
                    </div>
                    <div class="card-footer border-secondary bg-transparent">
                        <div class="d-flex justify-content-between mt-2">
                            <h5 class="font-weight-bold">Total</h5>
                            <h5 class="font-weight-bold">$160</h5>
                        </div>
                        <button class="btn btn-block btn-primary my-3 py-3">Proceed To Checkout</button>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <!-- Cart End -->

</asp:Content>
