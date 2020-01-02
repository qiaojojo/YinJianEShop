<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SellerEditGood.aspx.cs" Inherits="YinJianEShop.Seller.SellerEditGood" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link type="text/css" rel="/Style/sellerOrderPage.css" />
</head>
<body>
    <form id="formEditGood" runat="server">
        <div class="divEditGood">
            <asp:GridView ID="gvEditGood" runat="server" DataKeyNames="Id" OnRowDeleting="gvEditGood_RowDeleting" OnRowUpdating="gvEditGood_RowUpdating" > 
                <Columns>
                    <asp:BoundField DataField="Id" HeaderText="商品ID" />
                    <asp:TemplateField HeaderText="图片预览">
                        <ItemTemplate>
                          <img src='<%# Eval("ImgUrl") %>' width="150px" height="150px" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="GoodName" HeaderText="商品名" />
                    <asp:BoundField DataField="GoodPrice" HeaderText="商品价格" />
                    <asp:BoundField DataField="AddedDate" HeaderText="添加时间" />
                    <asp:BoundField DataField="SellerName" HeaderText="添加人" />
                    <asp:TemplateField HeaderText="操作">
                        <ItemTemplate>
                            <asp:LinkButton ID="lbChangeGood" runat="server" CommandName="Update" >编辑商品</asp:LinkButton>
                            <asp:LinkButton ID="lbDelete" runat="server" CommandName="Delete" OnClientClick="return confirm('确认要删除吗？');">删除</asp:LinkButton>
                        </ItemTemplate> 
                </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
    </form>
</body>
</html>
