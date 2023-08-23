<%@ Page Title="" Language="C#" MasterPageFile="~/admin/admin.master" AutoEventWireup="true" CodeFile="A_AddProductCategory.aspx.cs" Inherits="admin_A_AddProductCategory" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div class="main-part">
            <div class="title">
                <h1>Add Products</h1>
                <a href="A_ProductList.aspx"><i class="fa fa-angle-left"></i>Back</a>
            </div>
            <div class="card">
                <div class="card-title">Add Products</div>
                <div class="card-body">
                    <div class="form-group">
                        <label>category:</label>
                        <asp:DropDownList ID="DropDownList1" runat="server" CssClass="form-control" AutoPostBack="True" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" ></asp:DropDownList>           
                    </div>
                    <div class="form-group">
                        <label>sub category:</label>
                        <asp:DropDownList ID="DropDownList2" runat="server" CssClass="form-control" AutoPostBack="True" OnSelectedIndexChanged="DropDownList2_SelectedIndexChanged"></asp:DropDownList>           
                    </div>
                    <div class="form-group">
                        <label>Third category:</label>
                        <asp:DropDownList ID="DropDownList3" runat="server" CssClass="form-control" AutoPostBack="True" OnSelectedIndexChanged="DropDownList3_SelectedIndexChanged"></asp:DropDownList>           
                    </div>
                    <div class="form-group">
                        <label>Brand</label>
                        <asp:DropDownList ID="DropDownList4" runat="server" CssClass="form-control"></asp:DropDownList>
                    </div>
                    <div class="form-group">
                        <label>Product Name</label>
                        <asp:TextBox ID="TextBox1" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <label>Product Price</label>
                        <asp:TextBox ID="TextBox2" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <label>Product color</label>
                        <asp:TextBox ID="TextBox3" type="Color" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <label>Product image</label>
                        <div class="row">
                            <div class="col-9">
                                <asp:FileUpload ID="FileUpload1" runat="server" CssClass="form-control" />
                            </div>
                            <div class="col-3">
                                <asp:Image ID="Image1" runat="server" Height="200px" Width="200px" style="object-fit:contain;" />
                            </div>
                        </div>
                    </div>
                    <div class="form-group">
                        <label>Product Discription</label>
                        <asp:TextBox ID="TextBox4" runat="server" CssClass="form-control" ></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <label>Status:</label>
                        <asp:DropDownList ID="DropDownList5" runat="server" CssClass="form-control">
                        <asp:ListItem>Active</asp:ListItem>
                        <asp:ListItem>Deactive</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                    </div>
                    <div class="card-footer">
                        <asp:LinkButton ID="LinkButton1" CssClass="btn-save" runat="server" OnClick="LinkButton1_Click" ><i class="fa fa-save"></i>&nbsp;Save</asp:LinkButton>
                        <div class="btn-cancel">
                            <i class="fa fa-times"></i>
                            <input id="reset" type="reset" value="Cancle"/>
                        </div>
                    </div>
                </div>
            </div>
</asp:Content>

