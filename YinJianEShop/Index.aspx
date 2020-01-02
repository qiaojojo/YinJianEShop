<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="Index.aspx.cs" Inherits="YinJianEShop.Index" %>

<asp:Content ContentPlaceHolderID="head" ID="goodsHead" runat="server">
    <link rel="stylesheet" type="text/css" href="/Style/goodsIndexPage.css">
</asp:Content>

<asp:Content ContentPlaceHolderID="MainContent" ID="MainPage" runat="server">
    <div class="divMenu">
        <asp:Label ID="labHello" runat="server" Text=""></asp:Label>&nbsp;
        <asp:LinkButton ID="lbtnLogin" runat="server" Visible="true" OnClick="lbtnLogin_Click">登录</asp:LinkButton>&nbsp;&nbsp;
        <asp:LinkButton ID="lbtnRegister" runat="server" Visible="true" OnClick="lbtnRegister_Click">注册</asp:LinkButton>&nbsp;&nbsp;
        <asp:LinkButton ID="lbtnUserOrder" runat="server" Visible="false" OnClick="lbtnUserOrder_Click">订单管理</asp:LinkButton>&nbsp;&nbsp;
        <asp:LinkButton ID="lbtnAddress" runat="server" Visible="false" OnClick="lbtnAddress_Click">管理收货地址</asp:LinkButton>&nbsp;&nbsp;
        <asp:ImageButton ID="btnCart" CssClass=".shoppingCart" ImageUrl="/Images/Page/Cart.png" runat="server" OnClick="btnCart_Click" Visible="false" />
    </div>
    <div class="divGoodList" id="divGoodList">
    <asp:ListView ID="lvGoodList" runat="server">
        <ItemTemplate>
            <div class="divGood">
            <p><a href="/GoodShow.aspx?id=<%# Eval("Id")%>"><img src="<%# Eval("ImgUrl") %>" /></a></p>
            <br>
            <h2><%# Eval("GoodName")%></h2>
            <p>价格：<%# Eval("GoodPrice")%>元</p>
            <asp:Button ID="btnAddCart" CssClass="button" runat="server" Text="加入购物车" CommandArgument='<%# Eval("Id") %>' OnClick="btnAddCart_Click" />
        </div>
        </ItemTemplate>
    </asp:ListView>
    </div>
</asp:Content>
