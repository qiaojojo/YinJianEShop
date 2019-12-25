<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="Index.aspx.cs" Inherits="YinJianEShop.Index" %>

<asp:Content ContentPlaceHolderID="head" ID="goodsHead" runat="server">
    <link rel="stylesheet" type="text/css" href="/Style/goodsIndexPage.css">
</asp:Content>

<asp:Content ContentPlaceHolderID="MainContent" ID="MainPage" runat="server">
    <div class="divMenu">
        <asp:ImageButton ID="btnCart" CssClass=".shoppingCart" ImageUrl="/Images/Page/Cart.png" runat="server" />
    </div>
    <div class="divGoodList" id="divGoodList" runat="server">
       <div class="divGood">
            <p><img src="/Images/Goods/大吉大利骨灰盒.jpg" alt="大吉大利骨灰盒" /></p>
            <br>
            <h2>大吉大利骨灰盒</h2>
            <p>PRICE: $449</p>
            <button class="add-to-cart" type="button" >加入购物车</button>
        </div>
    </div>
</asp:Content>
