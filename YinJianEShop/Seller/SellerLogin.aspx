<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SellerLogin.aspx.cs" Inherits="YinJianEShop.Seller.SellerLogin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>卖家登录</title>
<link type="text/css" rel="stylesheet" href="~/Style/login.css" />
</head>
<body>
    <form id="formSellerLogin" class="formBox" runat="server">
        <div class="divBox">
             <h2>卖家登录</h2>
             账&nbsp;号&nbsp;<asp:TextBox ID="txtSellerNum" runat="server" CssClass="text"></asp:TextBox><br />
             密&nbsp;码&nbsp;<asp:TextBox ID="txtSellerPasswd" runat="server" CssClass="text" TextMode="Password"></asp:TextBox><br />
            <asp:Label ID="labError" runat="server" Text=""></asp:Label><br />
            <asp:Button ID="btnLogin" runat="server" Text="登录" CssClass="Button" OnClick="btnLogin_Click" />
         </div>
    </form>
</body>
</html>
