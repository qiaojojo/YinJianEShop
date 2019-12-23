<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserRegister.aspx.cs" Inherits="YinJianEShop.Users.UserRegister" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>用户注册</title>
<link rel="stylesheet" href="~/Style/login.css" />
</head>
<body>
    <form id="formUserRegister" class="formBox" runat="server">
        <div class="divBox">
             <h2>用户注册</h2>
            <table>
                <tr>
                    <td>姓名</td>
                    <td>
                        <asp:TextBox ID="txtUserName" runat="server" CssClass="text"></asp:TextBox>
                    </td>
                    <td></td>
                </tr>
                <tr>
                    <td>邮箱</td>
                    <td>
                        <asp:TextBox ID="txtUserNum" runat="server" CssClass="text"></asp:TextBox><br />
                    </td>
                    <td></td>
                </tr>
                <tr>
                    <td>密码</td>
                    <td>
                        <asp:TextBox ID="txtUserPasswd" runat="server" CssClass="text" TextMode="Password"></asp:TextBox>
                    </td>
                    <td></td>
                </tr>
                <tr>
                    <td>确认密码</td>
                    <td>
                        <asp:TextBox ID="txtUserPasswdSure" runat="server" CssClass="text"></asp:TextBox>
                    </td>
                    <td></td>
                </tr>
                
                <tr>
                    <td>性别</td>
                    <td>
                        <asp:RadioButtonList ID="RadioButtonList1" runat="server" CssClass="text"></asp:RadioButtonList>
                    </td>
                    <td></td>
                </tr>
                <tr>
                    <td>身份证号</td>
                    <td>
                        <asp:TextBox ID="txtUserIdentification" runat="server" CssClass="text"></asp:TextBox>
                    </td>
                    <td></td>
                </tr>
                <tr>
                    <td>联系电话</td>
                    <td>
                        <asp:TextBox ID="txtUserTelephone" runat="server" CssClass="text"></asp:TextBox></td>
                    <td></td>
                </tr>
            </table>
         </div>
        <br />
        <asp:Button ID="btnRegister" runat="server" Text="遁入阴间" CssClass="Button" />
    </form>
</body>
</html>
