<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserLogin.aspx.cs" Inherits="YinJianEShop.UserLogin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>用户登录</title>
<link rel="stylesheet" href="~/Style/login.css" />
</head>
<body>
    <form id="formUserLogin" class="formBox" runat="server">
         <div class="divBox">
             <h2>用户登录</h2>
             账&nbsp;号&nbsp;<asp:TextBox ID="txtUserNum" runat="server" CssClass="text"></asp:TextBox><br />
             密&nbsp;码&nbsp;<asp:TextBox ID="txtUserPasswd" runat="server" CssClass="text" TextMode="Password"></asp:TextBox><br />
             <asp:Button ID="btnLogin" runat="server" Text="登录" CssClass="Button" />
         </div>
    </form>
</body>
</html>
