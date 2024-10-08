﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminPanel.aspx.cs" Inherits="Vogue.AdminP" %>

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
                        <asp:Button runat="server" ID="productbtn" CssClass="btn btn-secondary m-2" Text="Products"/>
                        <asp:Button runat="server" ID="orderbtn" CssClass="btn btn-primary m-2" Text="Orders" PostBackUrl="~/AdminOrders.aspx"/>
                    </div>
                  
                    <div class="row mt-5">
                        <div class="col-6">
                            <h2 class="text-dark">Products</h2>
                        </div>
                        <div class="col-6 text-right">
                            <asp:Button runat="server" ID="addBtn" Text="+" CssClass="btn btn-outline-primary rounded" OnClick="addBtn_Click" />
                          
                        </div>
                    </div>

                    <table class="table table-bordered">
                        <thead>
                            <tr>
                                <th>Id</th>
                                <th>Name</th>
                                <th>Description</th>
                                <th>Price</th>
                                <th>Stock</th>
                                <th>CategoryId</th>
                                <th>Image</th>
                            </tr>
                        </thead>
                        <tbody>

                            <asp:Repeater runat="server" ID="productRepeater">
                                <ItemTemplate>
                                    <tr>
                                        <td>
                                            <%# Eval("ProductId") %>
                                        </td>
                                        <td>
                                            <%# Eval("Name") %>
                                        </td>
                                        <td>
                                            <%# Eval("Description") %>
                                        </td>
                                        <td>
                                            <%# Eval("Price") %>
                                        </td>
                                        <td>
                                            <%# Eval("Stock") %>
                                        </td>
                                        <td>
                                           <%# Eval("CategoryId") %>
                                        </td>
                                        <td style="width:200px;">
                                            <asp:Image runat="server" ImageUrl='<%# Eval("ImageUrl") %>' CssClass="img-fluid" style="width:100%; height:150px; object-fit:cover;" />
                                        </td>
                                        <td>
                                            <asp:LinkButton runat="server" CssClass="btn rounded btn-outline-primary" CommandName="Edit" CommandArgument='<%# Eval("ProductId") %>' OnCommand="editBtn_Command" ID="editBtn" Text="Edit"/>
                                        </td>
                                        <td style="width:120px;">
                                            <asp:LinkButton runat="server" CssClass="btn rounded btn-outline-primary" CommandName="Remove" CommandArgument='<%# Eval("ProductId") %>' OnCommand="deleteBtn_Command" ID="deleteBtn" Text="Stock out" />
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
