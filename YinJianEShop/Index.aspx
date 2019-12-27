<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="Index.aspx.cs" Inherits="YinJianEShop.Index" %>

<asp:Content ContentPlaceHolderID="head" ID="goodsHead" runat="server">
    <link rel="stylesheet" type="text/css" href="/Style/goodsIndexPage.css">
</asp:Content>

<asp:Content ContentPlaceHolderID="MainContent" ID="MainPage" runat="server">
    <div class="divMenu">
        <asp:ImageButton ID="btnCart" CssClass=".shoppingCart" ImageUrl="/Images/Page/Cart.png" runat="server" OnClick="btnCart_Click" />
    </div>
    <div class="divGoodList" id="divGoodList">
    <asp:ListView ID="lvGoodList" runat="server">
        <ItemTemplate>
            <div class="divGood">
            <p><a href="/GoodShow.aspx?id=<%# Eval("Id")%>"><img src="<%# Eval("ImgUrl") %>" /></a></p>
            <br>
            <h2><%# Eval("GoodName")%></h2>
            <p>价格：<%# Eval("GoodPrice")%>元</p>
            <asp:LinkButton ID="btnbuy" CssClass="button" runat="server" Text="立即购买" CommandArgument='<%# Eval("Id") %>' OnClick="btnbuy_Click" />
            <asp:LinkButton ID="btnAddCart" CssClass="button" runat="server" Text="加入购物车" CommandArgument='<%# Eval("Id") %>' OnClick="btnAddCart_Click" />
        </div>
        </ItemTemplate>
    </asp:ListView>
    </div>
</asp:Content>
