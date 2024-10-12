<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminOrders.aspx.cs" Inherits="Vogue.AdminOrders" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Vogue</title>
    <!-- Font Awesome -->
    <link href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/5.10.0/css/all.min.css" rel="stylesheet"/>

     <!-- Customized Bootstrap Stylesheet -->
    <link href="css/style.css" rel="stylesheet"/>

</head>
<body>
    <form id="form1" runat="server">
        <div class="container-fluid">
            <main role="main" class="py-3 mx-5">
                <div>
                    <div class="row justify-content-between pt-3">
                        <h1 class="text-primary font-weight-semi-bold">Vogue</h1>
                        <h2 class="text-center text-dark pt-1">Admin Panal</h2>
                        <div class="pt-1">
                            <asp:Button runat="server" ID="logoutBtn" Text="Logout" CssClass="btn btn-primary rounded" OnClick="logoutBtn_Click" />
                        </div>
                    </div>
                    <div class="row justify-content-center mt-2">
                        <asp:Button runat="server" ID="productbtn" CssClass="btn btn-primary m-2" Text="Products" PostBackUrl="~/AdminPanel.aspx"/>
                        <asp:Button runat="server" ID="orderbtn" CssClass="btn btn-secondary m-2" Text="Orders"/>
                    </div>
                    <div class="row mt-5 py-2">
                        <div class="col-6">
                            <h2 class="text-dark">Orders</h2>
                        </div>
                    </div>

                    <table class="table table-bordered">
                        <thead>
                            <tr>
                                <th>OrderId</th>
                                <th>UserId</th>
                                <th>Order Date</th>
                                <th>Payment Method</th>
                                <th>Total Amount</th>
                                <th>Shipping Address</th>
                                <th>Order Status</th>
                            </tr>
                        </thead>
                        <tbody>

                            <asp:Repeater runat="server" ID="orderRepeater" OnItemDataBound="Repeater1_ItemDataBound">
                                <ItemTemplate>
                                    <tr>
                                        <td>
                                            <%# Eval("OrderId") %>
                                        </td>
                                        <td>
                                            <%# Eval("UserId") %>
                                        </td>
                                        <td>
                                            <%# Eval("OrderDate") %>
                                        </td>
                                        <td>
                                            <%# Eval("PaymentMethod") %>
                                        </td>
                                        <td>
                                           <%# Eval("TotalAmount") %>
                                        </td>
                                        <td>
                                            <%# Eval("ShippingAddress") %>
                                        </td>
                                         <td>
                                           <%# Eval("OrderStatus") %>
                                        </td>
                                        <td style="width:100px;">
                                            <asp:LinkButton runat="server" CssClass="btn rounded btn-primary" CommandName="Packed" CommandArgument='<%# Eval("OrderId") %>' OnCommand="packBtn_Command" ID="packBtn" Text="Packed"/>
                                        </td>
                                        <td style="width:100px;">
                                            <asp:LinkButton runat="server" CssClass="btn rounded btn-primary" CommandName="Shipped" CommandArgument='<%# Eval("OrderId") %>' OnCommand="shipBtn_Command" ID="shipBtn" Text="Shipped" />
                                        </td>
                                        <td style="width:100px;">
                                            <asp:LinkButton runat="server" CssClass="btn rounded btn-primary" CommandName="Delivered" CommandArgument='<%# Eval("OrderId") %>' OnCommand="deliverBtn_Command" ID="deliverBtn" Text="Delivered" />
                                        </td>
                                    </tr>
                                </ItemTemplate>
                            </asp:Repeater>

                        </tbody>
                    </table>

                </div>
            </main>
        </div>
    </form>
</body>
</html>
