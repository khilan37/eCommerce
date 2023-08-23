<%@ Page Language="C#" AutoEventWireup="true" CodeFile="login.aspx.cs" Inherits="admin_login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="css/StyleSheet.css" rel="stylesheet" />
    <title>Admin Login</title>
    <style>
        :root{
             --black: rgb(134, 131, 131);
             --bg-color: rgba(51, 49, 49);
             --box-shadow: 0 4px 8px 0 rgba(0, 0, 0, 0.2), 0 6px 20px 0 rgba(0, 0, 0, 0.19);
        }
        body{
            background-color:var(--bg-color);
           
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="login-container">
            <div class="login-body">
                <h1>YOUR<span>MART.</span></h1>
                <h3>Admin Panel</h3>
                    <asp:TextBox ID="TextBox1" placeholder="username" CssClass="form-control" runat="server"></asp:TextBox>               
                    <asp:TextBox ID="TextBox2" placeholder="password" TextMode="Password" CssClass="form-control" runat="server"></asp:TextBox>
                    <asp:LinkButton ID="LinkButton1"  CssClass="form-btn" runat="server" OnClick="LinkButton1_Click" >Enter</asp:LinkButton>                    
              </div>
        </div>
    </form>
</body>
</html>
