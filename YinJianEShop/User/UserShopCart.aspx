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
        <asp:Label ID="labMessege" runat="server" Text=""></asp:Label><br />
        <asp:GridView ID="gvUserCart" BorderColor="Black" CssClass="gvUserCart" runat="server"  DataKeyNames="Id" OnRowDataBound="gvUserCart_RowDataBound" AutoGenerateColumns="False" OnRowDeleting="gvUserCart_RowDeleting" OnRowUpdating="gvUserCart_RowUpdating">
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

                <asp:TemplateField HeaderText="更改数量">
                        <ItemTemplate>
                            <asp:TextBox ID="txtNum" runat="server"></asp:TextBox>
                            <asp:Button ID="btnChangeNum" CssClass="button" runat="server" Text="更改" CommandName="update"  />
                        </ItemTemplate>
                    </asp:TemplateField>

                <asp:TemplateField HeaderText="更新" >
                        <ItemTemplate>
                            <asp:Button ID="btnGoodDelete" CssClass="button" runat="server" Text="删除"  CommandName="delete" />
                        </ItemTemplate> 
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
        <br />
        <asp:Button ID="btnBuy" CssClass="button" runat="server" Text="提交订单" OnClick="btnBuy_Click" />
    </div>
</asp:Content>