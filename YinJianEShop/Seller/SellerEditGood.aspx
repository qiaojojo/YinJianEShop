<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SellerEditGood.aspx.cs" Inherits="YinJianEShop.Seller.SellerEditGood" %>

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
    <form id="formEditGood" runat="server">
        <div class="divEditGood">
            <asp:GridView ID="gvEditGood" runat="server">
                <Columns>
                    <asp:BoundField DataField="GoodName" HeaderText="商品名" />
                    <asp:BoundField DataField="GoodPrice" HeaderText="商品价格" />
                    <asp:BoundField DataField="AddedDate" HeaderText="添加时间" />
                    <asp:BoundField DataField="SellerName" HeaderText="添加人" />
                    <asp:TemplateField HeaderText="操作">
                        <ItemTemplate>
                            <asp:LinkButton ID="lbDelete" runat="server">删除</asp:LinkButton>
                        </ItemTemplate> 
                </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
    </form>
</body>
</html>
