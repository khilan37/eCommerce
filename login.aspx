<%@ Page Title="" Language="C#" MasterPageFile="~/home.master" AutoEventWireup="true" CodeFile="login.aspx.cs" Inherits="login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="login-container">
        <div class="container">
            <div class="login-form">
                <h1>YOUR<span>MART.</span></h1>
                <h3>Login</h3>
                <asp:Label ID="Label1" runat="server" Text="Label">Username</asp:Label>
                <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                <asp:Label ID="Label3" runat="server" Text="Label">Password</asp:Label>
                <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
                <asp:Button ID="Button1" runat="server" Text="Login" OnClick="Button1_Click" />
                <p>New to Yourmart?<a href="registration.aspx">Create account</a></p>
            </div>
        </div>
    </div>
</asp:Content>

