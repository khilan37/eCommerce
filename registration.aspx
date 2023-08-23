<%@ Page Title="" Language="C#" MasterPageFile="~/home.master" AutoEventWireup="true" CodeFile="registration.aspx.cs" Inherits="registration" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="login-container">
        <div class="container">
            <div class="login-form">
                <h1>YOUR<span>MART.</span></h1>
                <h3>Create Account</h3>
                <asp:Label ID="Label1" runat="server" Text="Label">Username</asp:Label>
                <asp:TextBox ID="TextBox1" runat="server" AutoPostBack="True" OnTextChanged="TextBox1_TextChanged"></asp:TextBox>
                <asp:Label ID="Label2" runat="server" Text="Label">Email</asp:Label>
                <asp:TextBox ID="TextBox2" runat="server" TextMode="Email" AutoPostBack="True" OnTextChanged="TextBox2_TextChanged"></asp:TextBox>
                <asp:Label ID="Label3" runat="server" Text="Label">Password</asp:Label>
                <asp:TextBox ID="TextBox3" runat="server" TextMode="Password"></asp:TextBox>
                <asp:Button ID="Button1" runat="server" Text="Create account" OnClick="Button1_Click" />
                <p>Existing user?<a href="login.aspx">Log in</a></p>
            </div>
        </div>
    </div>
</asp:Content>

