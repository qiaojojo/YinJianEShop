<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="UserGoodOrder.aspx.cs" Inherits="YinJianEShop.User.UserGoodOrder" %>

<asp:Content ContentPlaceHolderID="head" ID="goodsHead" runat="server">
    <link rel="stylesheet" type="text/css" href="/Style/userGoodOrder.css">
</asp:Content>

<asp:Content ContentPlaceHolderID="MainContent" ID="MainPage" runat="server">
    <div class="divMenu">
        <a href="/Index.aspx">返回首页</a>
        <asp:ImageButton ID="btnCart" CssClass=".shoppingCart" ImageUrl="/Images/Page/Cart.png" runat="server" />
    </div>
    
    <div class="divGoodOrder">
        <div class="divUserAddress">
            <h2>收货地址</h2>
            <asp:RadioButtonList ID="rblUserAddress" CssClass="gvUserCart" runat="server"></asp:RadioButtonList>
        </div><br />
        <h2>订单详情</h2>
        <asp:GridView ID="gvUserGoodOrder" CssClass="gvUserCart" runat="server"  DataKeyNames="Id" OnRowCommand="gvUserCart_RowCommand">
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
        <div class="UserSure">
            <p>合计：<asp:Label ID="labPriceSum" runat="server" Text="****" ForeColor="Red"></asp:Label>元</p>
            <asp:Button ID="btnPostOrder" CssClass="button" runat="server" Text="确认提交" OnClick="btnPostOrder_Click" />
        </div>
    </div>
</asp:Content>