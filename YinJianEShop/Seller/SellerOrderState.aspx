<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SellerOrderState.aspx.cs" Inherits="YinJianEShop.Seller.SellerOrderState" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
<link type="text/css" rel="stylesheet" href="/Style/sellerOrderPage.css" />
</head>
<body>
    <form id="formOrderState" runat="server">
        <div>
            <h2>订单详情</h2>
            <asp:GridView ID="gvOrderState"  BorderColor="Black" CssClass="gvUserCart" runat="server" AutoGenerateColumns="False">
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
            <div style="text-align:left;">
                总金额：<asp:Label ID="labPriceSum" runat="server" Text="" ForeColor="Red"></asp:Label>元<br />
                状态：<asp:Label ID="labStatus" runat="server" Text=""></asp:Label><br />
                收件人：<asp:Label ID="labReceiver" runat="server" Text=""></asp:Label><br />
                收件地址：<asp:Label ID="labAddress" runat="server" Text=""></asp:Label><br />
                联系方式：<asp:Label ID="labTelephone" runat="server" Text=""></asp:Label><br />
            </div>
            <asp:Button ID="btnBack" CssClass="button" runat="server" Text="返回" OnClick="btnBack_Click" />
        </div>
    </form>
</body>
</html>
