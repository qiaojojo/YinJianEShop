<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="UserPayOrder.aspx.cs" Inherits="YinJianEShop.User.UserPay" %>

<asp:Content ContentPlaceHolderID="head" ID="goodsHead" runat="server">
    <link rel="stylesheet" type="text/css" href="/Style/userGoodOrder.css">
</asp:Content>

<asp:Content ContentPlaceHolderID="MainContent" ID="MainPage" runat="server">
    <div class="divMenu">
        <a href="/Index.aspx">返回首页</a>
        <a href="/User/UserShopCart.aspx"><img Class=".shoppingCart" src="/Images/Page/Cart.png" /></a>
    </div>
    <div class="divGoodOrder">
        <asp:GridView ID="gvGoodOrder" runat="server"></asp:GridView>

    </div>
</asp:Content>