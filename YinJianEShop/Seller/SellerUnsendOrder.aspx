<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SellerUnsendOrder.aspx.cs" Inherits="YinJianEShop.Seller.SellerUnsendOrder" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
<link type="text/css" rel="stylesheet" href="/Style/sellerOrderPage.css" />
</head>
<body>
    <form id="formUnsendOrder" runat="server">
        <div>
            <h2>未发货订单</h2><br />
            <div>
                订单号搜索:<asp:TextBox ID="txtOrderNum" runat="server"></asp:TextBox>
                <asp:Button ID="btnSearch" CssClass="button" runat="server" Text="搜索" OnClick="btnSearch_Click" />
            </div>
            <asp:GridView ID="gvGoodOrder"  BorderColor="Black" CssClass="gvUserCart" runat="server" OnRowUpdating="gvGoodOrder_RowUpdating" AutoGenerateColumns="False"  >
            <Columns>
                <asp:BoundField DataField="OrderId" HeaderText="订单id" />
                <asp:TemplateField HeaderText="预览">
                        <ItemTemplate>
                          <img src='<%# Eval("ImgUrl") %>' width="150px" height="150px" />
                        </ItemTemplate>
                    </asp:TemplateField>
                <asp:BoundField DataField="OrderNum" HeaderText="订单号" />
                <asp:BoundField DataField="CreateDate" HeaderText="创建日期" />
                <asp:BoundField DataField="PayDate" HeaderText="付款日期" />
                <asp:TemplateField HeaderText="快递单号">
                        <ItemTemplate>
                            <asp:TextBox ID="txtCourierNum" runat="server"></asp:TextBox>
                        </ItemTemplate> 
                </asp:TemplateField>
                <asp:BoundField DataField="Address" HeaderText="收货地址" />
                <asp:TemplateField HeaderText="确认发货">
                        <ItemTemplate>
                            <asp:Button ID="btnSend" runat="server" Text="确认发货" CommandName="update" />
                        </ItemTemplate> 
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
        </div>
    </form>
</body>
</html>
