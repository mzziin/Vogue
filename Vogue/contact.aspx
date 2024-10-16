﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Contact.aspx.cs" Inherits="Vogue.Contact" %>

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
                            <a href="contact.aspx" class="nav-item nav-link active">Contact</a>
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
    <div class="container-fluid my-3 my-sm-0">
        <div class="d-flex flex-column align-items-start justify-content-center ml-lg-5 ml-sm-1" style="min-height: 200px">
            <h1 class="font-weight-semi-bold text-uppercase mb-3">Contact Us</h1>
            <div class="d-inline-flex">
                <p class="m-0"><a href="index.aspx">Home</a></p>
                <p class="m-0 px-2">-</p>
                <p class="m-0">Contact</p>
            </div>
        </div>
    </div>
    <!-- Page Header End -->
    <!-- Contact Start -->
    <div class="container-fluid">
        <div class="row px-xl-5">
            <div class="col-lg-7 mb-5">
                <div class="contact-form">
                    <div id="success"></div>
                    <form name="sentMessage" id="contactForm" novalidate="novalidate">
                        <div class="control-group">
                            <asp:TextBox runat="server" placeholder="Name" ID="name" CssClass="form-control"></asp:TextBox>
                            <p class="help-block text-danger"></p>
                        </div>
                        <div class="control-group">
                            <asp:TextBox runat="server" placeholder="Your Email" ID="email" CssClass="form-control"></asp:TextBox>
                            <p class="help-block text-danger"></p>
                        </div>
                        <div class="control-group">
                            <asp:TextBox runat="server" placeholder="Subject" ID="subject" CssClass="form-control"></asp:TextBox>
                            <p class="help-block text-danger"></p>
                        </div>
                        <div class="control-group">
                            <asp:TextBox runat="server" TextMode="MultiLine" ID="message" placeholder="Message" CssClass="form-control"></asp:TextBox>
                            <p class="help-block text-danger"></p>
                        </div>
                        <div>
                            <asp:Button runat="server" ID="btn" Text="Send Message" CssClass="btn btn-primary py-2 px-4" OnClick="btn_Click" />
                        </div>
                    </form>
                </div>
            </div>
            <div class="col-lg-5 mb-5">
                <h5 class="font-weight-semi-bold mb-3">Get In Touch</h5>
                <p>We’d love to hear from you! Whether you have a question about our products, need assistance with an order, or just want to share your feedback, we’re here to help. 
                    Fill out the form, send us an email, or give us a call, and we’ll get back to you as soon as possible.</p>
                <div class="d-flex flex-column mb-3">
                    <h5 class="font-weight-semi-bold mb-3">Store 1</h5>
                    <p class="mb-2"><i class="fa fa-map-marker-alt text-primary mr-3"></i>123 Street, New York, USA</p>
                    <p class="mb-2"><i class="fa fa-envelope text-primary mr-3"></i>Vogue.info@gmail.com</p>
                    <p class="mb-2"><i class="fa fa-phone-alt text-primary mr-3"></i>+012 345 67890</p>
                </div>
                <div class="d-flex flex-column">
                    <h5 class="font-weight-semi-bold mb-3">Store 2</h5>
                    <p class="mb-2"><i class="fa fa-map-marker-alt text-primary mr-3"></i>123 Street, New York, USA</p>
                    <p class="mb-2"><i class="fa fa-envelope text-primary mr-3"></i>info@example.com</p>
                    <p class="mb-0"><i class="fa fa-phone-alt text-primary mr-3"></i>+012 345 67890</p>
                </div>
            </div>
        </div>
    </div>
    <!-- Contact End -->
</asp:Content>
