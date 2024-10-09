<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminOrders.aspx.cs" Inherits="Vogue.AdminOrders" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <main role="main" class="py-3">
                <div>
                    <div class="row justify-content-between pt-3">
                        <h1 class="text-primary font-weight-semi-bold">Vogue</h1>
                        <h2 class="text-center text-dark pt-1">Admin Panal</h2>
                        <div class="pt-1">
                            <asp:Button runat="server" ID="logoutBtn" Text="Logout" CssClass="btn btn-primary rounded" OnClick="logoutBtn_Click" />
                        </div>
                        
                    </div>
                    <div class="row mt-5 py-2">
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
