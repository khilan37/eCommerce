<%@ Page Title="" Language="C#" MasterPageFile="~/admin/admin.master" AutoEventWireup="true" CodeFile="A_ThirdCategoryList.aspx.cs" Inherits="admin_A_ThirdCategoryList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="main-part">
            <div class="title">
                <h1>ThirdCategory List</h1>
                <a href="A_AddThirdCategory.aspx"><i class="fa fa-plus"></i>Add</a>
            </div>
            <div class="card">
                <div class="card-title">ThirdCategory</div>
             <div class="table-view">
            <asp:GridView ID="GridView1" OnRowCommand="GridView1_RowCommand"  AutoGenerateColumns="false" runat="server" CssClass="table">
                <Columns>
                    <asp:TemplateField HeaderText="ID">
                        <ItemTemplate>
                            <%#Eval("tc_id") %>
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
                    <asp:TemplateField HeaderText="STATUS">
                        <ItemTemplate>
                            <%#Eval("status") %>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="EDIT">
                        <ItemTemplate>
                            <a href="a_addthirdCategory.aspx?Edit=<%#Eval("tc_id")%>" class="btn">Edit</a>
                        </ItemTemplate>
                        <HeaderStyle Width="100px" />
                        <ItemStyle Width="100px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="DELETE">
                        <ItemTemplate>
                            <asp:LinkButton ID="LinkButton1" CssClass="btn" OnClientClick="return confirm('are sure want to delete category?')" CommandArgument='<%#Eval("tc_id") %>' runat="server">Delete</asp:LinkButton>
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

