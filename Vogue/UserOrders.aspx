<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="UserOrders.aspx.cs" Inherits="Vogue.UserOrders" %>
<asp:Content ID="Content1" ContentPlaceHolderID="NavbarContent" runat="server">
    <div class="container-fluid">
        <div class="row border-top px-xl-5">
            <div class="col-lg-9">
                <nav class="navbar navbar-expand-lg bg-light navbar-light py-3 py-lg-0 px-0">
                    <a href="Index.aspx" class="text-decoration-none d-block d-lg-none">
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
    <div class="container-fluid">
        <div class="d-flex flex-column align-items-start justify-content-center ml-5" style="min-height: 200px">
            <h1 class="font-weight-semi-bold text-uppercase mb-3">Orders</h1>
            <div class="d-inline-flex">
                <p class="m-0"><a href="index.aspx">Home</a></p>
                <p class="m-0 px-2">-</p>
                <p class="m-0">Orders</p>
            </div>
        </div>
    </div>
    <!-- Page Header End -->

    <div class="container-fluid px-5">
        <table class="table">
            <tbody>
                <tr class="row mt-3 justify-content-between">
                    <th class="col-5">Product Name</th>
                    <th class="col">Price</th>
                    <th class="col">Quantity</th>
                    <th class="col">Payment method</th>
                    <th class="col">Order Status</th>
                </tr>
                <asp:Repeater runat="server" ID="order_repeater">
                    <ItemTemplate>
                        <tr class="row rounded border my-2 justify-content-between">
                            <td class="col-5">
                                <asp:Label runat="server" CssClass="h5" Text='<%# Eval("Name") %>'></asp:Label>
                            </td>
    
                            <td class="col">
                                <asp:Label runat="server" Text='<%# Eval("TotalPrice") %>'></asp:Label>
                            </td>
                            <td class="col">
                                <asp:Label runat="server" Text='<%# Eval("Quantity") %>'></asp:Label>
                            </td>
                            <td class="col">
                                <asp:Label runat="server" Text='<%# Eval("PaymentMethod") %>'></asp:Label>
                            </td>
                            <td class="col d-flex">
                                <div class="mr-2">
                                    <i class="fa fa-circle text-success" aria-hidden="true"></i>
                                </div>
                                <asp:Label runat="server" Text='<%# Eval("OrderStatus") %>'></asp:Label>
                          
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
            </tbody>           
        </table>
        
    </div>
</asp:Content>
