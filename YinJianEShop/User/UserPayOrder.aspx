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
        <h2>订单详情</h2>
        <asp:GridView ID="gvGoodOrder" BorderColor="Black" CssClass="gvUserCart" runat="server" AutoGenerateColumns="False" >
            <Columns>
                <asp:BoundField DataField="GoodName" HeaderText="商品名" />
                <asp:TemplateField HeaderText="图片预览">
                    <ItemTemplate>
                        <img src='<%# Eval("ImgUrl") %>' width="150px" height="150px" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="GoodPrice" HeaderText="单价" />
                <asp:BoundField DataField="GoodNum" HeaderText="数量" />
                <asp:BoundField DataField="GoodsPrice" HeaderText="价格" />           
            </Columns>
        </asp:GridView>
        <br />
        <div class="divUserSure">
            <p>总金额：<asp:Label ID="labPriceSum" runat="server" Text="" ForeColor="Red"></asp:Label>元</p>
            <asp:TextBox ID="txtPayNumber" runat="server" Visible="false"></asp:TextBox><br />
            <asp:Button ID="btnSurePay" CssClass="button" runat="server" Visible="false" Text="火钱已烧" OnClick="btnSurePay_Click" />
            <asp:Button ID="btnUserGet" CssClass="button" runat="server" Visible="false" Text="确认到货" OnClick="btnUserGet_Click" />
        </div>
    </div>
</asp:Content>