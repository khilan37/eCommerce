<%@ Page Title="" Language="C#" MasterPageFile="~/admin/admin.master" AutoEventWireup="true" CodeFile="A_ProductList.aspx.cs" Inherits="admin_A_ProductList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div class="main-part">
            <div class="title">
                <h1>ProductCategory List</h1>
                <a href="A_AddProductCategory.aspx"><i class="fa fa-plus"></i>Add</a>
            </div>
            <div class="card">
                <div class="card-title">Product List</div>
                <div class="table-view table-x">
            <asp:GridView ID="GridView1" OnRowCommand="GridView1_RowCommand" AutoGenerateColumns="false" runat="server" CssClass="table">
                <Columns>
                    <asp:TemplateField HeaderText="ID">
                        <ItemTemplate>
                            <%#Eval("product_id") %>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="CATEGORY">
                        <ItemTemplate>
                            <%#Eval("category") %>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="SUBCATEGORY">
                        <ItemTemplate>
                            <%#Eval("subcategory") %>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="THIRDCATEGORY">
                        <ItemTemplate>
                            <%#Eval("third_category") %>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="BRANDNAME">
                        <ItemTemplate>
                            <%#Eval("brand_name") %>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="NAME">
                        <ItemTemplate>
                            <%#Eval("product_name") %>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="PRICE">
                        <ItemTemplate>
                            <%#Eval("product_price") %>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="COLOR">
                        <ItemTemplate>
                            <span style="display:block; height:40px; width:40px; background-color:<%#Eval("product_color") %>"></span> 
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="IMAGE">
                        <ItemTemplate>
                             <asp:Image ImageUrl='<%#Eval("product_image") %>' Height="200" Width="200" Style="object-fit:contain;" ID="Image1" runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="DESCRIPTION">
                        <ItemTemplate>
                            <asp:TextBox Enabled="false"  ID="TextBox1" Height="120" Text='<%#Eval("product_description") %>' runat="server" TextMode="MultiLine"></asp:TextBox>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="STATUS">
                        <ItemTemplate>
                            <%#Eval("product_status") %>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="EDIT">
                        <ItemTemplate>
                            <a href="A_AddProductCategory.aspx?Edit=<%#Eval("product_id")%>" class="btn">Edit</a>
                        </ItemTemplate>
                        <HeaderStyle Width="100px" />
                        <ItemStyle Width="100px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="DELETE">
                        <ItemTemplate>
                            <asp:LinkButton ID="LinkButton1" CssClass="btn" OnClientClick="return confirm('are sure want to delete category?')" CommandArgument='<%#Eval("product_id") %>' runat="server">Delete</asp:LinkButton>
                        </ItemTemplate>
                        <HeaderStyle Width="100px" />
                        <ItemStyle Width="100px" />
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>

            </div>
        </div>
</asp:Content>

