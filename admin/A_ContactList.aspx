<%@ Page Title="" Language="C#" MasterPageFile="~/admin/admin.master" AutoEventWireup="true" CodeFile="A_ContactList.aspx.cs" Inherits="admin_A_ContactList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div class="main-part">
            <div class="title">
                <h1>Contact List</h1>
            </div>
            <div class="card">
                <div class="card-title">Contact List</div>
                <div class="table-view">
            <asp:GridView ID="GridView1" OnRowCommand="GridView1_RowCommand"  AutoGenerateColumns="false" runat="server" CssClass="table" >
                <Columns>
                    <asp:TemplateField HeaderText="ID">
                        <ItemTemplate>
                            <%#Eval("id") %>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="USERNAME">
                        <ItemTemplate>
                            <%#Eval("name") %>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="EMAIL">
                        <ItemTemplate>
                            <%#Eval("email") %>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="MESAAGE">
                        <ItemTemplate>
                            <%#Eval("message") %>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="DELETE">
                        <ItemTemplate>
                            <asp:LinkButton ID="LinkButton1" CssClass="btn" OnClientClick="return confirm('are sure want to delete category?')" CommandArgument='<%#Eval("id") %>' runat="server">Delete</asp:LinkButton>
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

