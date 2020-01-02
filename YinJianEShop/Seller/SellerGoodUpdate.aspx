<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SellerGoodUpdate.aspx.cs" Inherits="YinJianEShop.Seller.SellerGoodUpdate" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
<link type="text/css" rel="stylesheet" href="/Style/sellerOrderPage.css" />
</head>
<body>
    <form id="formGoodUpdate" runat="server">
        <div>
            <h2>更新商品信息</h2>
            <table>
                <tr>
                    <td>商品名</td>
                    <td>
                        <asp:TextBox ID="txtGoodName" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="rfvGoodName" ForeColor="Red" runat="server" ControlToValidate="txtGoodName" ErrorMessage="商品名不能为空！" ValidationGroup="formCheck"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>商品价格</td>
                    <td>
                        <asp:TextBox ID="txtGoodPrice" runat="server"></asp:TextBox></td>
                    <td>
                        <asp:RequiredFieldValidator ID="rfvGoodPrice" ForeColor="Red" runat="server" ControlToValidate="txtGoodPrice" ErrorMessage="商品价格不能为空！" ValidationGroup="formCheck"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>预览图片</td>
                    <td>
                        <img src="" runat="server" id="imgGoodImg"  width="200" height="200" />
                    </td>
                </tr>

                <tr>
                    <td>
                        <asp:CheckBox ID="checkUploadImg" runat="server" />更新图片
                    </td>
                    <td>
                        <asp:FileUpload ID="uploadImg" runat="server" />
                    </td>
                    <td>
                        <asp:Label ID="labUploadImg" ForeColor="Red" runat="server" Text=""></asp:Label>
                        <asp:RequiredFieldValidator ID="rfvUploadImg" ForeColor="Red" runat="server" ControlToValidate="uploadImg" ErrorMessage="上传图片不能为空！" ValidationGroup="formCheck"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>商品说明</td>
                    <td>
                        <asp:TextBox ID="txtRemark" runat="server"></asp:TextBox></td>
                    <td></td>
                </tr>
            </table>
            <asp:Label ID="labMessenge" ForeColor="Red" runat="server" Text=""></asp:Label><br />
            <asp:Button ID="btnGoodUpdate" runat="server" CssClass="button" Text="更新商品" ValidationGroup="formCheck" OnClick="btnGoodUpdate_Click" />
            <asp:Button ID="btnBack" runat="server" CssClass="button" Text="返回并取消" OnClick="btnBack_Click" />
        </div>
    </form>
</body>
</html>
