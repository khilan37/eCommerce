<%@ Page Title="" Language="C#" MasterPageFile="~/home.master" AutoEventWireup="true" CodeFile="all_productbrand.aspx.cs" Inherits="all_productbrand" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
  <div class="categories-container margin">
    <div class="container">
       <div class="all-categories color">
           <div class="row">
               <div class="col-12">
                   <h3>All Products Brands</h3>
               </div>
               <asp:Repeater ID="Repeater1" runat="server">
                   <ItemTemplate>
                        <div class="col-3">
                            <div class="category-box color">
                                <a href="productlist.aspx?cat_id=<%#Eval("cat_id")%>&sub_cat_id=<%#Eval("sub_cat_id")%>&tc_id=<%#Eval("tc_id") %>"><h1><%#Eval("third_category") %></h1></a> 
                            </div>
                        </div>
                   </ItemTemplate>
               </asp:Repeater>
           </div>
           <div class="margin center">
                   <a class="view" href="productlist.aspx">show all</a>
           </div>
       </div>
    </div>
</div>
</asp:Content>

