<%@ Page Title="" Language="C#" MasterPageFile="~/home.master" AutoEventWireup="true" CodeFile="viewcart.aspx.cs" Inherits="viewcart" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="mycart-container margin">
        <div class="container"> 
            <div class="row">
                <div class="col-8">
                    <div class="mycart color" ID="cart">
                        <div class="cart-header">
                            <h2>My cart</h2>
                        </div>
                        <div id="inCart" runat="server">
                            <asp:Repeater ID="Repeater1" runat="server" OnItemCommand="Repeater1_ItemCommand">
                                <ItemTemplate>
                                    <div class="cart-main color">
                                        <a href="ViewProduct.aspx?product_id=<%#Eval("product_id")%>">
                                            <asp:Image ID="Image1" CssClass="cart-img" ImageUrl='<%#Eval("product_image") %>'  runat="server" />
                                        </a>
                                        <div class="cart-pr-name">
                                            <a href="#"><asp:Label ID="Label1" runat="server"><%#Eval("product_name") %></asp:Label></a>
                                            <asp:Label ID="Label2" runat="server"><%#Eval("product_price") %></asp:Label>
                                            <div class="update-quantity">
                                                <asp:TextBox CssClass="qtext" ID="TextBox1" Text='<%#Eval("quantity") %>' runat="server"></asp:TextBox>
                                                <asp:LinkButton ID="LinkButton1"  CommandName="Update"  CommandArgument='<%#Eval("cart_id") %>' CssClass="q-btn view" runat="server">Update</asp:LinkButton>
                                            </div>
                                            <asp:LinkButton ID="LinkButton2"  CommandName="delete"   CommandArgument='<%#Eval("product_id") %>' OnClientClick="return confirm('are you sure want to delete add  product ?')"  CssClass="r-btn view"  runat="server">Remove</asp:LinkButton>
                                        </div>
                                    </div>
                                </ItemTemplate>
                            </asp:Repeater>
                        </div>
                        <div class="aftercart" id="notinCart" runat="server">
                            <asp:Label ID="Label11"  CssClass="after-lb1" runat="server"></asp:Label>
                            <asp:Label ID="Label12" CssClass="after-lb2" runat="server"></asp:Label>
                            <asp:LinkButton ID="LinkButton5"  CssClass="view after-btn" runat="server" OnClick="LinkButton5_Click">Login</asp:LinkButton>
                        </div>
                        <div class="cart-footer">
                            <asp:LinkButton ID="LinkButton3" CssClass="f-btn view" runat="server" OnClick="LinkButton3_Click">Continue Shopping</asp:LinkButton>
                            <asp:LinkButton ID="LinkButton4" CssClass="f-btn1 view" runat="server" OnClick="LinkButton4_Click">Place Order</asp:LinkButton>
                        </div>
                    </div>
                </div>
                <div class="col-4 price">
                    <div class="price-container color">
                        <div class="price-header">
                            <h2>Price Details</h2>
                        </div>
                        <div class="price-main-part">
                            <div class="row">
                            <div class="col-6">
                                 <asp:Label ID="Label3" CssClass="p-lbl" runat="server" Text="Price"></asp:Label>
                                 <asp:Label ID="Label5" runat="server" CssClass="p-lbl" Text="Quantity"></asp:Label>
                                 <asp:Label ID="Label7" CssClass="p-lbl" runat="server" Text="Delivery Charges"></asp:Label>
                            </div>
                            <div class="col-6">
                                 <asp:Label ID="Label4" CssClass="p-lbl" runat="server" Text="49,000"></asp:Label>
                                  <asp:Label ID="Label6" runat="server" CssClass="p-lbl" Text="1"></asp:Label>
                                <asp:Label ID="Label8" CssClass="p-lbl" runat="server" Text="free"></asp:Label>
                            </div>
                        </div>
                        </div>
                        <div class="price-footer">
                            <div class="row">
                                <div class="col-6">
                                <asp:Label ID="Label9" CssClass="p-lbl" runat="server" Text="Amount Payable"></asp:Label>    
                                </div>
                                <div class="col-6">
                                <asp:Label ID="Label10" CssClass="p-lbl" runat="server" Text="free"></asp:Label>    
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

