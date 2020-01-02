<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="UserGoodOrder.aspx.cs" Inherits="YinJianEShop.User.UserGoodOrder" %>

<asp:Content ContentPlaceHolderID="head" ID="goodsHead" runat="server">
    <link rel="stylesheet" type="text/css" href="/Style/userGoodOrder.css">
</asp:Content>

<asp:Content ContentPlaceHolderID="MainContent" ID="MainPage" runat="server">
    <div class="divMenu">
        <a href="/Index.aspx">返回首页</a>
        <a href="/User/UserShopCart.aspx"><img Class=".shoppingCart" src="/Images/Page/Cart.png" /></a>
    </div>
    
    <div class="divGoodOrder">
        <div class="divUserAddress">
            <h2>收货地址</h2>
            <asp:Label ID="labMessege" runat="server" Text="" ForeColor="Red"></asp:Label><br />
            <asp:RadioButtonList ID="rblUserAddress" CssClass="gvUserCart" runat="server"></asp:RadioButtonList><br />
            <asp:LinkButton ID="lbtnAddAddress" runat="server" OnClick="lbtnAddAddress_Click">添加地址</asp:LinkButton>
        </div><br />
        <h2>订单详情</h2>
        <asp:GridView ID="gvUserGoodOrder"  BorderColor="Black" CssClass="gvUserCart" runat="server" AutoGenerateColumns="False" OnRowDataBound="gvUserGoodOrder_RowDataBound" >
            <Columns>
                <asp:BoundField DataField="Id" HeaderText="商品Id" />
                <asp:BoundField DataField="GoodName" HeaderText="商品名" />
                <asp:TemplateField HeaderText="图片预览">
                    <ItemTemplate>
                        <img src='<%# Eval("ImgUrl") %>' width="150px" height="150px" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="GoodPrice" HeaderText="单价" />

                <asp:TemplateField HeaderText="数量">
                        <ItemTemplate>
                            <asp:Label ID="labGoodNum" runat="server" Text=""></asp:Label>
                        </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="价格">
                        <ItemTemplate>
                            <asp:Label ID="labGoodsPrice" runat="server" Text=""></asp:Label>
                        </ItemTemplate>
                </asp:TemplateField>     
            </Columns>
        </asp:GridView>
        <br />
        <asp:Button ID="btnPostOrder" CssClass="button" runat="server" Text="确认提交" OnClick="btnPostOrder_Click" />
    </div>
</asp:Content>