<%@ Page Title="" Language="C#" MasterPageFile="~/home.master" AutoEventWireup="true" CodeFile="home.aspx.cs" Inherits="home" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="slider-container">
       <div class="container">
           <div class="row">
               <div class="col-12">
                   <div class="slidershow">
                       <img src="" name="slide" alt="">
                   </div>
               </div>
           </div>
       </div>
   </div>     
   <div class="slider-brand">
       <div class="container">
           <div class="row">
               <div class="col-12">
                <div class="name">
                    <h3>Our Mobiles & Laptops Brands</h3>
                    <a class="view" href="#">View All</a>
                </div>
                   <div class="slider">
                    <div class="slide-track">
                        <div class="slide">
                            <a href="#">
                                <img src="images/z1.jpg" alt="">
                            </a>
                        </div>
                        <div class="slide">
                            <a href="#">
                                <img src="images/z2.jpg" alt="">
                            </a>
                        </div>
                        <div class="slide">
                            <a href="#">
                                <img src="images/z3.jpg" alt="">
                            </a>
                        </div>
                        <div class="slide">
                            <a href="#">
                                <img src="images/z4.jpg" alt="">
                            </a>
                        </div>
                        <div class="slide">
                            <a href="#">
                                <img src="images/z5.jpg" alt="">
                            </a>
                        </div>
                        <div class="slide">
                            <a href="#">
                                <img src="images/z6.jpg" alt="">
                            </a>
                        </div>
                        <div class="slide">
                            <a href="#">
                                <img src="images/z7.jpg" alt="">
                            </a>
                        </div>
                        <div class="slide">
                            <a href="#">
                                <img src="images/z8.jpg" alt="">
                            </a>
                        </div>
                        <div class="slide">
                            <a href="#">
                                <img src="images/z9.jpg" alt="">
                            </a>
                        </div>
                    </div>
               </div>
           </div>
       </div>
   </div>
</div>
<asp:Repeater ID="Repeater1" OnItemDataBound="Repeater1_ItemDataBound" runat="server">
    <ItemTemplate>
        <asp:HiddenField ID="HiddenField1" Value='<%#Eval("sub_cat_id") %>' runat="server" />
        <div class="mobile-list">
            <div class="container">
                <div class="row">
                    <div class="col-12">
                        <div class="name">
                            <h3><%#Eval("subcategory") %></h3>
                            <a class="view" href="productlist.aspx?sub_cat_id=<%#Eval("sub_cat_id")%>">More</a>
                        </div>
                    </div>
                    <asp:Repeater ID="Repeater2" runat="server">
                        <ItemTemplate>
                            <div class="col-3">
                                <div class="mobile-box">
                                    <a href="viewproduct.aspx?product_id=<%#Eval("product_id")%>">
                                    <div class="mobile-img">
                                        <asp:Image ID="Image1" ImageUrl='<%#Eval("product_image") %>' runat="server" />
                                    </div>
                                    </a>
                                    <h3><%#Eval("product_name") %></h3>
                                    <h4><%#Eval("product_price") %></h4>
                                </div>
                            </div>
                            </ItemTemplate>
                    </asp:Repeater>
                </div>
            </div>
        </div>
    </ItemTemplate>
</asp:Repeater>
</asp:Content>

