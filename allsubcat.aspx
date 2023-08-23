<%@ Page Title="" Language="C#" MasterPageFile="~/home.master" AutoEventWireup="true" CodeFile="allsubcat.aspx.cs" Inherits="allsubcat" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="categories-container margin">
    <div class="container">
       <div class="all-categories color">
           <div class="row">
               <div class="col-12">
                   <h3>Sub Categories</h3>
               </div>
               <asp:Repeater ID="Repeater1" runat="server">
                    <ItemTemplate>
                        <div class="col-3">
                            <div class="category-box color">
                            <a href="all_productbrand.aspx?cat_id=<%#Eval("cat_id")%>&sub_cat_id=<%#Eval("sub_cat_id")%>"><h1><%#Eval("subcategory")%></h1></a> 
                            </div>
                        </div>
                   </ItemTemplate>
               </asp:Repeater>
           </div>
       </div>
    </div>
</div>
</asp:Content>

