<%@ Page Title="" Language="C#" MasterPageFile="~/home.master" AutoEventWireup="true" CodeFile="ViewProduct.aspx.cs" Inherits="ViewProduct" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="product-container margin ">
        <div class="container">
            <div class="productview color">
                <div class="row">
                    <div class="col-6">
                        <div class="product-img">
                        <asp:Image ID="Image1" runat="server" />                        
                        </div>
                    </div>
                    <div class="col-6">
                        <div class="product-details">
                                <div class="product-lb">
                                    <asp:Label ID="Label5" CssClass="p1-lbl lb-size" runat="server" Text="Product Name:"></asp:Label>
                                    <asp:Label ID="Label1" CssClass="p1-lbl"  runat="server" Text="Label"></asp:Label>
                                </div>
                                <div class="product-lb">
                                    <asp:Label ID="Label6" CssClass="p1-lbl lb-size" runat="server" Text="Product Description:"></asp:Label>
                                    <asp:Label ID="Label2" CssClass="p1-lbl" runat="server" Text="Label"></asp:Label>
                                </div>
                                <div class="lb-flex">
                                    <div class="product-lb">
                                        <asp:Label ID="Label7" CssClass="p1-lbl lb-size" runat="server" Text="product-price"></asp:Label>
                                        <asp:Label ID="Label3" CssClass="p1-lbl" runat="server" Text="Label"><i class="fa fa-rupee-sign fa-2x"></i></asp:Label>
                                    </div>
                                    <div class="product-lb">
                                        <asp:Label ID="Label4" CssClass="p1-lbl lb-size" runat="server" Text="Label">Product Quantity</asp:Label>
                                        <asp:TextBox ID="TextBox1"  CssClass="qtext" Text="1" runat="server"></asp:TextBox>
                                    </div>
                                </div>
                          </div>
                    </div>
                </div>
                 <div class="product-btn">
                                <div class="row">
                                    <div class="col-6" id="addbtn" runat="server">
                                        <asp:LinkButton  ID="LinkButton3" CssClass="view pbtn" runat="server" OnClick="LinkButton3_Click">Add to Cart</asp:LinkButton>
                                    </div>
                                    <div class="col-6" id="gobtn" runat="server">
                                        <asp:LinkButton  ID="LinkButton1" CssClass="view pbtn" runat="server" OnClick="LinkButton1_Click">Go to Cart</asp:LinkButton>
                                    </div>
                                    <div class="col-6">
                                        <asp:LinkButton ID="LinkButton4" CssClass="view pbtn" runat="server">Buy Now</asp:LinkButton>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
        </asp:Content>

