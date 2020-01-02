<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SellerAddGood.aspx.cs" Inherits="YinJianEShop.Seller.SellerAddGood" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link type="text/css" rel="/Style/sellerOrderPage.css" />
</head>
<body>
    <form id="formAddGood" runat="server">
        <div>
            <h2>添加商品</h2>
            <table>
                <tr>
                    <td>商品名</td>
                    <td>
                        <asp:TextBox ID="txtGoodName" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="rfvGoodName" ForeColor="Red" runat="server" ControlToValidate="txtGoodName" ErrorMessage="商品名不能为空！"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>商品价格</td>
                    <td>
                        <asp:TextBox ID="txtGoodPrice" runat="server"></asp:TextBox></td>
                    <td>
                        <asp:RequiredFieldValidator ID="rfvGoodPrice" ForeColor="Red" runat="server" ControlToValidate="txtGoodPrice" ErrorMessage="商品价格不能为空！"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                
                <tr>
                    <td>添加图片</td>
                    <td>
                        <asp:FileUpload ID="uploadImg" runat="server" />
                    </td>
                    <td>
                        <asp:Label ID="labUploadImg" ForeColor="Red" runat="server" Text=""></asp:Label>
                        <asp:RequiredFieldValidator ID="rfvUploadImg" ForeColor="Red" runat="server" ControlToValidate="uploadImg" ErrorMessage="上传图片不能为空！"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>商品说明</td>
                    <td>
                        <asp:TextBox ID="txtRemark" runat="server"></asp:TextBox></td>
                    <td></td>
                </tr>
            </table>
            <asp:Button ID="btnGoodAdd" runat="server" CssClass="button" Text="添加商品" OnClick="btnGoodAdd_Click" />
        </div>
    </form>
</body>
</html>
