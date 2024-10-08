﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Cart.aspx.cs" Inherits="Vogue.Cart" EnableEventValidation="false"  %>


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
            <h1 class="font-weight-semi-bold text-uppercase mb-3">Shopping Cart</h1>
            <div class="d-inline-flex">
                <p class="m-0"><a href="index.aspx">Home</a></p>
                <p class="m-0 px-2">-</p>
                <p class="m-0">Shopping Cart</p>
            </div>
        </div>
    </div>
    <!-- Page Header End -->

    <div class="container-fluid">
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

                        <asp:Repeater ID="repeat_cart_product" runat="server" OnItemCommand="repeat_cart_product_ItemCommand">
                        <ItemTemplate>
                        <tr>
                            <td class=" pl-5 text-left">
                                <asp:Image ID="Image1" ImageUrl='<%# Eval("ImageUrl") %>' runat="server"  style="width: 50px;"/>
                                <asp:Label runat="server" ID="Label2" Text='<%# Eval("ProductName") %>'></asp:Label>
                                <asp:Label runat="server" ID="cartid" Text='<%# Eval("CartId") %>' Visible="false"></asp:Label>
                            </td>
                            <td class="align-middle">
                                &#8377;<asp:Label runat="server" ID="unitlabel" Text='<%# Eval("UnitPrice") %>'></asp:Label>
                            </td>
                            <td class="align-middle">
                                <div class="input-group quantity mx-auto" style="width: 100px;">
                                    <div class="input-group-btn">
                                        <asp:Button runat="server" Text="-" ID="btnminus" CommandName="minus" CommandArgument='<%# Eval("ProductId") %>' CssClass="btn btn-sm btn-primary btn-minus"/>
                                    </div>
                                    <asp:Label runat="server" Text='<%# Eval("Quantity") %>' ID="qty" class="form-control form-control-sm bg-secondary text-center"></asp:Label>
                                    <div class="input-group-btn">
                                         <asp:Button runat="server" Text="+" ID="btnplus" CommandName="plus" CommandArgument='<%# Eval("ProductId") %>' CssClass="btn btn-sm btn-primary btn-plus"/>
                                    </div>
                                </div>
                            </td>
                            <td class="align-middle">
                                &#8377;<asp:Label runat="server" ID="totalprice" Text='<%# Eval("TotalPrice") %>'></asp:Label>
                            </td>
                            <td class="align-middle">                                    
                                <asp:Button runat="server" CommandName="remove" CommandArgument='<%# Eval("ProductId") %>' ID="rmbtn" Text="X" CssClass="btn btn-primary" />
                            </td>
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
                        <div class="d-flex justify-content-between mt-2">
                            <h6 class="font-weight-medium">Subtotal</h6>
                            <h6>
                                &#8377;<asp:Label runat="server" CssClass="font-weight-medium" ID="totalsum" Text=""></asp:Label>
                            </h6>
                        </div>
                        <div class="d-flex justify-content-between mt-3">
                            <h6 class="font-weight-medium">Shipping</h6>
                            <h6>
                                <asp:Label runat="server" CssClass="font-weight-medium" ID="shipping1" Text="">Free</asp:Label>
                            </h6>
                        </div>
                    </div>
                    <div class="card-footer border-secondary bg-transparent">
                        <div class="d-flex justify-content-between mt-3">
                            <h5 class="font-weight-bold">Grand Total</h5>
                            <h5 class="font-weight-bold">
                                &#8377;<asp:Label runat="server" ID="totalsum1" Text=""></asp:Label>
                            </h5>
                        </div>
                        <asp:Button ID="checkoutbtn" CssClass="btn btn-block btn-primary my-3 py-3" Text="Proceed To Checkout" runat="server" OnClick="checkoutbtn_Click" />
                    </div>
                </div>
            </div>
        </div>
    </div>
    <!-- Cart End -->

</asp:Content>
