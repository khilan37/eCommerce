<%@ Page Title="" Language="C#" MasterPageFile="~/home.master" AutoEventWireup="true" CodeFile="productlist.aspx.cs" Inherits="productlist" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="productlist-container margin">
        <div class="container">
            <div class="productlist">
                <div class="products color">
                    <h1>Products</h1>
                </div>
                <div class="row">
                    <asp:Repeater ID="Repeater1" runat="server">
                        <ItemTemplate>
                            <div class="col-3">
                                <div class="product">
                                    <div class="mobile-box">
                                        <a href="viewproduct.aspx?product_id=<%#Eval("product_id")%>">
                                        <div class="mobile-img">
                                            <asp:Image ID="Image1"  runat="server" ImageUrl='<%#Eval("product_image") %>'  />
                                        </div>
                                        </a>
                                        <h3><%#Eval("product_name") %></h3>
                                        <h4><%#Eval("product_price") %></h4>
                                    </div>
                                </div>
                            </div>
                         </ItemTemplate>
                    </asp:Repeater>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

