<%@ Page Title="" Language="C#" MasterPageFile="~/home.master" AutoEventWireup="true" CodeFile="allcategories.aspx.cs" Inherits="allcategories" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div class="categories-container margin">
    <div class="container">
       <div class="all-categories color">
           <div class="row">
               <div class="col-12">
                   <h3>All Categroies</h3>
               </div>
               <asp:Repeater ID="Repeater1" runat="server">
                    <ItemTemplate>
                        <div class="col-3">
                            <div class="category-box color">
                                <a href="allsubcat.aspx?cat_id=<%#Eval("cat_id")%>"><h1><%#Eval("category")%></h1></a> 
                            </div>
                        </div>
                    </ItemTemplate>
               </asp:Repeater>
           </div>
       </div>
    </div>
</div>
</asp:Content>

