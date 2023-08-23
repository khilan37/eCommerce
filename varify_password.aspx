<%@ Page Title="" Language="C#" MasterPageFile="~/home.master" AutoEventWireup="true" CodeFile="varify_password.aspx.cs" Inherits="varify_password" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="password-container margin">
        <div class="container">
            <div class="row">
                <div class="col-12">
                    <div class="password color">
                        <div class="verification">
                            <h1>YOUR<span>MART.</span></h1>
                            <h3>Enter Verfication number</h3>
                            <asp:TextBox  ID="TextBox1" CssClass="num" runat="server"></asp:TextBox>
                            <asp:TextBox ID="TextBox2" CssClass="num" runat="server"></asp:TextBox>
                            <asp:TextBox ID="TextBox3" CssClass="num" runat="server"></asp:TextBox>
                            <asp:TextBox ID="TextBox4" CssClass="num" runat="server"></asp:TextBox>
                            <div class="btn-cotnainer">
                            <asp:LinkButton ID="LinkButton1" CssClass="view btn" runat="server" OnClick="LinkButton1_Click">Check</asp:LinkButton>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

