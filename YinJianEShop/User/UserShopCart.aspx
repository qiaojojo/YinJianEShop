<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="UserShopCart.aspx.cs" Inherits="YinJianEShop.User.UserShopCart" %>

<asp:Content ContentPlaceHolderID="head" ID="goodsHead" runat="server">
    <link rel="stylesheet" type="text/css" href="/Style/userShopCart.css">
</asp:Content>

<asp:Content ContentPlaceHolderID="MainContent" ID="MainPage" runat="server">
    <div class="divMenu">
        <a href="/Index.aspx">返回首页</a>
       <a href="/User/UserShopCart.aspx"><img Class=".shoppingCart" src="/Images/Page/Cart.png" /></a>
    </div>
    <div class="divUserCart">
        <asp:Label ID="labMessege" runat="server" Text=""></asp:Label>
        <asp:GridView ID="gvUserCart" CssClass="gvUserCart" runat="server"  DataKeyNames="Id" OnRowCommand="gvUserCart_RowCommand">
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
                <asp:TemplateField HeaderText="更改数量">
                        <ItemTemplate>
                            <asp:TextBox ID="strNum" runat="server"></asp:TextBox>
                        </ItemTemplate>
                    </asp:TemplateField>
                <asp:TemplateField HeaderText="更新">
                        <ItemTemplate>
                            <asp:Button ID="btnChangeNum" CssClass="button" runat="server" Text="更改" CommandName="update" />
                            <asp:Button ID="btnGoodDelete" CssClass="button" runat="server" Text="删除" CommandName="delete" />
                        </ItemTemplate> 
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
        <asp:Button ID="btnBuy" CssClass="button" runat="server" Text="提交订单" OnClick="btnBuy_Click" />
    </div>
</asp:Content>