<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminUpdateProduct.aspx.cs" Inherits="Vogue.AdminUpdateProduct" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Vogue</title>

    <!-- Customized Bootstrap Stylesheet -->
    <link href="css/style.css" rel="stylesheet"/>

</head>
<body>
    <form id="form1" runat="server">
         <div class="container px-5">

            <div class="row">
                <h1 class="font-weight-semi-bold text-primary py-3">Vogue</h1>
            </div>
            <div class="row">
                <h2 class="text-dark">Add Product</h2>
            </div>

            <div class="row mb-3 p-1">
                <label class="p-0">Name</label>
                <asp:TextBox runat="server" ID="pname" CssClass="form-control" BorderColor="LightGray"></asp:TextBox>
                <asp:RequiredFieldValidator 
                    ID="rfvName" 
                    runat="server" 
                    ControlToValidate="pname" 
                    ErrorMessage="Name is required." 
                    CssClass="text-danger" 
                    Display="Dynamic">
                </asp:RequiredFieldValidator>
            </div>

            <div class="row mb-3 p-1">
                <label class="p-0">Description</label>
                <asp:TextBox runat="server" ID="description" TextMode="MultiLine" CssClass="form-control" BorderColor="LightGray"></asp:TextBox>
                <asp:RequiredFieldValidator 
                    ID="RequiredFieldValidator1" 
                    runat="server" 
                    ControlToValidate="description" 
                    ErrorMessage="Description is required." 
                    CssClass="text-danger" 
                    Display="Dynamic">
                </asp:RequiredFieldValidator>
            </div>

            <div class="row justify-content-between mb-4 p-1">
                <div class="col-6 p-0 pr-4">
                    <label>Price</label>
                    <asp:TextBox TextMode="Number" ID="price" runat="server" CssClass="form-control" BorderColor="LightGray"></asp:TextBox>
                    <asp:RequiredFieldValidator 
                        ID="RequiredFieldValidator2" 
                        runat="server" 
                        ControlToValidate="price" 
                        ErrorMessage="Price is required" 
                        CssClass="text-danger" 
                        Display="Dynamic">
                    </asp:RequiredFieldValidator>
                    <asp:RangeValidator 
                        ID="rvPrice" 
                        runat="server" 
                        ControlToValidate="price" 
                        MinimumValue="1" 
                        MaximumValue="1000000" 
                        Type="Integer" 
                        ErrorMessage="Price must be between 1 and 1000." 
                        CssClass="text-danger" 
                        Display="Dynamic">
                    </asp:RangeValidator>
                </div>
                <div class="col-6 p-0 pl-4">
                    <label>Stock</label>
                    <asp:TextBox runat="server" ID="stock" TextMode="Number" CssClass="form-control" BorderColor="LightGray"></asp:TextBox>
                    <asp:RequiredFieldValidator 
                        ID="RequiredFieldValidator3" 
                        runat="server" 
                        ControlToValidate="stock" 
                        ErrorMessage="Enter a valid stock amount" 
                        CssClass="text-danger" 
                        Display="Dynamic">
                    </asp:RequiredFieldValidator>
                    <asp:RangeValidator 
                        ID="RangeValidator1" 
                        runat="server" 
                        ControlToValidate="stock" 
                        MinimumValue="1" 
                        MaximumValue="1000" 
                        Type="Integer" 
                        ErrorMessage="Stock must be between 1 and 1000." 
                        CssClass="text-danger" 
                        Display="Dynamic">
                    </asp:RangeValidator>
                </div>
                
            </div>

            <div class="row justify-content-between mb-3 p-1">
                <div class="col-6 p-0 pr-4">
                    <label>Category</label>
                    <asp:DropDownList runat="server" ID="categoryDropDown" CssClass="form-control" BorderColor="LightGray">
                    </asp:DropDownList>
                </div>
                <div class="col-6 p-0 pl-4">
                    <label>Upload Image</label>
                    <asp:FileUpload runat="server" ID="imgUpload" CssClass="form-control" BorderColor="LightGray" />
                    <asp:RequiredFieldValidator 
                        ID="rfvImage" 
                        runat="server" 
                        ControlToValidate="imgUpload" 
                        ErrorMessage="Please upload an image." 
                        InitialValue="" 
                        CssClass="text-danger" 
                        Display="Dynamic">
                    </asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator 
                        ID="revImage" 
                        runat="server" 
                        ControlToValidate="imgUpload" 
                        ValidationExpression="^.*\.(jpg|jpeg|png)$" 
                        ErrorMessage="Only .jpg, .jpeg and .png files are allowed." 
                        CssClass="text-danger" 
                        Display="Dynamic">
                    </asp:RegularExpressionValidator>
                </div>
            </div>

            <div class="row justify-content-center my-5">
                <asp:Button runat="server" Text="Update" Width="100px" ID="updateBtn" CssClass="btn btn-primary rounded mr-3" OnClick="updateBtn_Click" />
                <asp:Button runat="server" Text="Cancel" Width="100px" ID="cancelBtn" CssClass="btn btn-primary rounded ml-3" OnClick="cancelBtn_Click" CausesValidation="False" />               
            </div>

        </div>
    </form>
</body>
</html>
