<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="UserShopCart.aspx.cs" Inherits="YinJianEShop.User.UserShopCart" %>

<asp:Content ContentPlaceHolderID="head" ID="goodsHead" runat="server">
    <link rel="stylesheet" type="text/css" href="/Style/userShopCart.css">
</asp:Content>

<asp:Content ContentPlaceHolderID="MainContent" ID="MainPage" runat="server">
    <div class="divMenu">
        <a href="/Index.aspx">返回首页</a>
        <asp:ImageButton ID="btnCart" CssClass=".shoppingCart" ImageUrl="/Images/Page/Cart.png" runat="server" />
    </div>
    <div class="divUserCart">
        <asp:GridView ID="gvUserCart" CssClass="gvUserCart" runat="server">
            <Columns>
                <asp:TemplateField HeaderText="操作">

                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>