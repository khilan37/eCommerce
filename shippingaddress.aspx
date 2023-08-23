<%@ Page Title="" Language="C#" MasterPageFile="~/home.master" AutoEventWireup="true" CodeFile="shippingaddress.aspx.cs" Inherits="shippingaddress" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="shipping-container">
        <div class="container">
            <div class="shipping color margin">
                <div class="row" id="div" runat="server">
                    <div class="col-6" id="div1" runat="server">
                        <div class="add-address color">
                            <h1 class="center">SHIPPING ADDRESS.</h1>
                            <asp:Label ID="Label1" runat="server" Text="FullName"></asp:Label>
                            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                            <asp:Label ID="Label2" runat="server" Text="City"></asp:Label>
                            <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
                            <asp:Label ID="Label3" runat="server" Text="State"></asp:Label>
                            <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
                            <asp:Label ID="Label4" runat="server" Text="Pincode"></asp:Label>
                            <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
                            <asp:Label ID="Label5" runat="server" Text="Mobile No"></asp:Label>
                            <asp:TextBox ID="TextBox5" runat="server"></asp:TextBox>
                            <asp:Label ID="Label6" runat="server" Text="Address"></asp:Label>
                            <asp:TextBox ID="TextBox6" runat="server" CssClass="address" Height="100px" TextMode="MultiLine"></asp:TextBox>
                            <asp:Button ID="Button1" runat="server" Text="Button" OnClick="Button1_Click" />
                        </div>
                    </div>
                    <div id="div2" class="col-6" runat="server">
                        <div class="select-address color"  >
                            <div class="select-add">
                                <h1>Shipping Address List</h1>
                                <asp:LinkButton ID="LinkButton1" CssClass="view btn"  OnClick="add_btn" runat="server"><i class="fa fa-plus"></i></asp:LinkButton>                                    
                            </div>
                            <asp:Repeater ID="Repeater1" runat="server">
                                <ItemTemplate>
                                    <div class="address color">
                                        <div class="add-lbl-container">
                                            <asp:Label ID="Label7" CssClass="address-lbl" runat="server" Text='<%#Eval("full_name") %>'></asp:Label>
                                            <asp:Label ID="Label8" CssClass="address-lbl" runat="server" Text='<%#Eval("city") %>'></asp:Label>
                                            <asp:Label ID="Label9" CssClass="address-lbl" runat="server" Text='<%#Eval("state") %>'></asp:Label>
                                            <asp:Label ID="Label10" CssClass="address-lbl" runat="server" Text='<%#Eval("pincode") %>'></asp:Label>
                                            <asp:Label ID="Label11" CssClass="address-lbl" runat="server" Text='<%#Eval("Mobile_number") %>'></asp:Label>
                                            <asp:Label ID="Label12" CssClass="address-lbl"  runat="server" Text='<%#Eval("Address") %>'></asp:Label>
                                        </div>
                                        <div class="address-btn">
                                            <asp:LinkButton ID="LinkButton2" CssClass="view btn" CommandArgument='<%#Eval("shipping_id")%>' OnCommand="edit_btn" runat="server" ><i class="fa fa-pen"></i></asp:LinkButton>
                                            <asp:LinkButton ID="LinkButton3" CssClass="view btn"  OnCommand="delete_btn" OnClientClick="return confirm('are you sure want to delete address ?')"  CommandArgument='<%#Eval("shipping_id") %>' runat="server"><i class="fa fa-trash-alt"></i></asp:LinkButton>                                    
                                            <a href="order-summary.aspx?shipping_id=<%#Eval("shipping_id")%>" class="view btn"><i class="fa fa-arrow-right"></i></a>
                                        </div>
                                    </div>
                                 </ItemTemplate>
                            </asp:Repeater>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

