<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="GoodShow.aspx.cs" Inherits="YinJianEShop.GoodShow" %>

<asp:Content ContentPlaceHolderID="head" ID="goodsHead" runat="server">
    <link rel="stylesheet" type="text/css" href="/Style/goodShowPage.css">
</asp:Content>

<asp:Content ContentPlaceHolderID="MainContent" ID="MainPage" runat="server">
    <div class="divMenu">
        <a href="/Index.aspx">返回首页</a>
        <asp:ImageButton ID="btnCart" CssClass=".shoppingCart" ImageUrl="/Images/Page/Cart.png" runat="server" />
    </div>
    <div class="divGoodShow">
    <asp:FormView ID="FormViewItem" runat="server">
        <ItemTemplate>
            <table width="940" border="0" align="center" cellpadding="0" cellspacing="0">
                <tr>
                    <td width="442" height="502" rowspan="15" valign="top"><img src="<%# Eval("GoodImg")%>" width="440" height="300" /></td>
                    <td width="2" rowspan="15" valign="top" bgcolor="#000000"></td>
                    <td width="480" height="28" valign="middle" class="ItemLine">商品名称：<asp:Label ID="LaItemName" runat="server" Text='<%# Eval("GoodName")%>'></asp:Label></td>
                </tr>
                <tr>
                    <td height="28" valign="middle" class="ItemLine">价格：<%# Eval("GoodPrice")%></td>
                </tr>
                <tr>
                    <td height="28" valign="middle" class="ItemLine">上架日期：<%# Eval("AddedDate")%></td>
                </tr>
                <tr>
                    <td height="28" valign="middle" class="ItemLine">商家：<%# Eval("Adder")%></td>
                </tr>
                <tr>
                    <td valign="middle" class="ItemLine">商品说明：<br /><asp:Label ID="LaPrice" runat="server" Text='<%# Eval("Remark")%>'></asp:Label></td>
                </tr>
                <tr>
                    <td height="28" valign="middle" class="ItemLine"></td>
                </tr>
                <tr>
                    <td height="56" valign="middle" style="text-align:center;" class="ItemLine">
                        <asp:Button ID="btnBuy" runat="server" CssClass="btn" Text="立即购买" />
                        <asp:Button ID="btnAddCart" runat="server" CssClass="btn" Text="加入购物车" />
                    </td>
                </tr>
                <tr>
                    <td height="28" valign="top" class="ItemLine"></td>
                </tr>
             </table>
        </ItemTemplate>
    </asp:FormView>
    </div>
</asp:Content>