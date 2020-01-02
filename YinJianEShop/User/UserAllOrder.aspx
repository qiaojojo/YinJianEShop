<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="UserAllOrder.aspx.cs" Inherits="YinJianEShop.User.UserAllOrder" %>

<asp:Content ContentPlaceHolderID="head" ID="goodsHead" runat="server">
    <link rel="stylesheet" type="text/css" href="/Style/userGoodOrder.css">
</asp:Content>

<asp:Content ContentPlaceHolderID="MainContent" ID="MainPage" runat="server">
    <div class="divMenu">
        <a href="/Index.aspx">返回首页</a>
        <a href="/User/UserShopCart.aspx"><img Class=".shoppingCart" src="/Images/Page/Cart.png" /></a>
    </div>
    <div class="divGoodOrder">
        <h2>用户订单</h2>
        <div>
            订单号搜索<asp:TextBox ID="txtSearch" runat="server"></asp:TextBox>
            <asp:Button ID="btnSearch" CssClass="button" runat="server" Text="搜索" OnClick="btnSearch_Click" />
        </div>
        <asp:GridView ID="gvGoodOrder" CssClass="gvUserCart" runat="server" OnRowCommand="gvGoodOrder_RowCommand" OnRowDataBound="gvGoodOrder_RowDataBound" >
            <Columns>
                <asp:BoundField DataField="OrderId" HeaderText="订单id" />
                <asp:BoundField DataField="OrderNum" HeaderText="订单号" />
                <asp:BoundField DataField="CreateDate" HeaderText="创建日期" />
                <asp:BoundField DataField="PayDate" HeaderText="付款日期" />
                <asp:BoundField DataField="SendDate" HeaderText="发货日期" />
                <asp:BoundField DataField="UserGetDate" HeaderText="收货日期" />
                <asp:BoundField DataField="CourierNum" HeaderText="快递单号" />
                <asp:BoundField DataField="Address" HeaderText="收货地址" />
                <asp:BoundField DataField="OrderStatus" HeaderText="订单状态" />
                <asp:TemplateField HeaderText="详情">
                        <ItemTemplate>
                            <asp:LinkButton ID="lbtnState" runat="server" CommandName="status">详情</asp:LinkButton>
                        </ItemTemplate> 
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>