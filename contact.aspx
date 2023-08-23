<%@ Page Title="" Language="C#" MasterPageFile="~/home.master" AutoEventWireup="true" CodeFile="contact.aspx.cs" Inherits="contact" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <div class="login-container">
        <div class="container">
            <div class="login-form">
                <h1>YOUR<span>MART.</span></h1>
                <h3>Contact Us</h3>
                <asp:Label ID="Label1" runat="server" Text="Label">Username</asp:Label>
                <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                <asp:Label ID="Label2" runat="server" Text="Label">Email</asp:Label>
                <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
                <asp:Label ID="Label3" runat="server" Text="Label">Address</asp:Label>
                <asp:TextBox ID="TextBox3" runat="server" TextMode="MultiLine" Style="display:block;width:100%; height:100px; margin-bottom:10px; outline:none; border:none; border-radius:3px;margin-top:5px;"></asp:TextBox>
                <asp:Button ID="Button1" runat="server" Text="Submit" OnClick="Button1_Click" />
            </div>
        </div>
    </div>
</asp:Content>

