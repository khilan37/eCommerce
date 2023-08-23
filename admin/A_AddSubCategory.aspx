<%@ Page Title="" Language="C#" MasterPageFile="~/admin/admin.master" AutoEventWireup="true" CodeFile="A_AddSubCategory.aspx.cs" Inherits="admin_A_AddSubCategory" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
 <div class="main-part">
            <div class="title">
                <h1>Add SubCategory</h1>
                <a href="A_SubCategoryList.aspx"><i class="fa fa-angle-left"></i>Back</a>
            </div>
            <div class="card">
                <div class="card-title">Add SubCategories</div>
                <div class="card-body">
                    <div class="form-group">
                        <label>Category:</label>
                        <asp:DropDownList ID="DropDownList1" runat="server" CssClass="form-control"></asp:DropDownList>
                    </div>
                    <div class="form-group">
                        <label>SubCategory:</label>
                        <asp:TextBox ID="TextBox1" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <label>Status:</label>
                      <asp:DropDownList ID="DropDownList2" runat="server" CssClass="form-control">
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

