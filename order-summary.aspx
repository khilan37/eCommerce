<%@ Page Title="" Language="C#" MasterPageFile="~/home.master" AutoEventWireup="true" CodeFile="order-summary.aspx.cs" Inherits="order_summary" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="order-container">
        <div class="container margin">
            <div class="row">
                <div class="col-8">
                    <div class="order-summary color">
                        <div class="login summary">
                            <h2>Login Details</h2>
                            <div class="login-d">
                            <asp:Label ID="Label1" runat="server" Text="UserName:"></asp:Label>
                            <asp:Label ID="Label2" runat="server" Text=""></asp:Label>
                            </div>
                         </div>
                        <div class="delivery-address summary">
                            <h2>Address Details</h2>         
                            <asp:Repeater ID="Repeater2" runat="server">
                                <ItemTemplate>
                                    <div class="address-d">    
                                        <div class="address-lbl-container">
                                        <asp:Label ID="Label11" CssClass="address-lbl" Text='<%#Eval("full_name") %>' runat="server" ></asp:Label>
                                        <asp:Label ID="Label12" CssClass="address-lbl" Text='<%#Eval("city") %>' runat="server" ></asp:Label>
                                        <asp:Label ID="Label13" CssClass="address-lbl" Text='<%#Eval("state") %>' runat="server" ></asp:Label>
                                        <asp:Label ID="Label14" CssClass="address-lbl" Text='<%#Eval("pincode") %>' runat="server" ></asp:Label>
                                        <asp:Label ID="Label15" CssClass="address-lbl" Text='<%#Eval("mobile_number") %>' runat="server" ></asp:Label>
                                        <asp:Label ID="Label16" CssClass="address-lbl" Text='<%#Eval("address") %>' runat="server" ></asp:Label>
                                        </div>
                                        <div class="address-sm-btn">
                                            <asp:LinkButton ID="LinkButton3"   CssClass="view display" runat="server" OnClick="LinkButton3_Click">Change</asp:LinkButton>                            
                                        </div>
                                    </div>
                                    <div class="edit-sm-address margintop10">
                                        <a href="shippingaddress.aspx?shipping_id=<%#Eval("shipping_id") %>" class="view display"><i class="fa fa-pen"></i></a>
                                    </div>
                                </ItemTemplate>
                            </asp:Repeater>
                        </div>
                        <div class="summary">
                            <h2>Order-Summary</h2>
                                    <div class="overflow-y">
                                                <asp:Repeater ID="Repeater1" OnItemCommand="Repeater1_ItemCommand" runat="server">
                                                    <ItemTemplate>
                                                        <div class="order-main color">
                                                            <a href="ViewProduct.aspx?product_id=<%#Eval("product_id")%>">
                                                                <asp:Image ID="Image1" CssClass="cart-img" ImageUrl='<%#Eval("product_image") %>'  runat="server" />
                                                            </a>
                                                            <div class="order-pr-name">
                                                                <a href="#"><asp:Label ID="Label1" runat="server"><%#Eval("product_name") %></asp:Label></a>
                                                                <asp:Label ID="Label2" runat="server"><%#Eval("product_price") %></asp:Label>
                                                                <div class="update-quantity">
                                                                    <asp:TextBox CssClass="qtext" ID="TextBox1" Text='<%#Eval("quantity") %>' runat="server"></asp:TextBox>
                                                                    <asp:LinkButton ID="LinkButton1" CommandName="Update"  CommandArgument='<%#Eval("cart_id") %>' CssClass="q-btn view" runat="server">Update</asp:LinkButton>
                                                                </div>
                                                                <asp:LinkButton ID="LinkButton2" CommandName="delete"  CommandArgument='<%#Eval("product_id") %>' OnClientClick="return confirm('are you sure want to delete add  product ?')"  CssClass="r-btn view"  runat="server">Remove</asp:LinkButton>
                                                            </div>
                                                         </div>
                                                    </ItemTemplate>
                                                </asp:Repeater>
                            </div>
                            <div class="edit-sm-address margintop10">
                                <asp:LinkButton ID="LinkButton4"  CssClass="view display" runat="server"><i class="fa fa-arrow-right"></i></asp:LinkButton>
                            </div>
                        </div>
                        <div class="payment summary">
                            <h2>Payment-Option</h2>
                            <div class="edit-sm-address margintop10">
                                <asp:LinkButton ID="LinkButton5"  CssClass="view display" runat="server"><i class="fa fa-arrow-right"></i></asp:LinkButton>
                            </div>
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

