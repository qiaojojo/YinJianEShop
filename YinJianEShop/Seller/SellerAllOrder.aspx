<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SellerAllOrder.aspx.cs" Inherits="YinJianEShop.Seller.SellerAllOrder" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
    *{
        margin:0;
        padding:0;
    }
    body{
        text-align:center;
        background:#808080;
    }
    form{
        display:inline-block;
    }
    div{
        color:white;
    }
    .button {
        border: 1px solid #ffffff;
        padding: 4px 14px;
        background-color: #000000;
        color: #ffffff;
        text-transform: uppercase;
        margin: 5px 0;
        font-weight: 400;
        cursor: pointer;
        border-radius: 50px;
    }
</style>
</head>
<body>
    <form id="formAllOrder" runat="server">
        <div>
            <h2>全部订单</h2>
            <div>
                订单号搜索<asp:TextBox ID="txtSearch" runat="server"></asp:TextBox>
                <asp:Button ID="btnSearch" CssClass="button" runat="server" Text="搜索" OnClick="btnSearch_Click" />
            </div>
            <asp:GridView ID="gvAllOrder" runat="server" OnRowDataBound="gvAllOrder_RowDataBound">
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
                </Columns>
            </asp:GridView>
        </div>
    </form>
</body>
</html>
