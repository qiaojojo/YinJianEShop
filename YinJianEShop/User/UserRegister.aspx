<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserRegister.aspx.cs" Inherits="YinJianEShop.User.UserRegister" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>用户注册</title>
    <link rel="stylesheet" href="~/Style/login.css" />
    <style type="text/css">
        .auto-style1 {
            width: 110px;
        }
    </style>
</head>
<body>
    <form id="formUserRegister" class="formBox" runat="server">
        <div class="divBox">
             <h2>用户注册</h2>
            <table>
                
                <tr>
                    <td class="auto-style1">*账号</td>
                    <td>
                        <asp:TextBox ID="txtUserNum" runat="server" CssClass="text"></asp:TextBox><br />
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="rfvUserNum" runat="server" ControlToValidate="txtUserNum" ErrorMessage="账号是必填项！" ValidationGroup="login"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style1">*密码</td>
                    <td>
                        <asp:TextBox ID="txtUserPasswd" runat="server" CssClass="text" TextMode="Password"></asp:TextBox>
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="rfvUserPasswd" runat="server" ControlToValidate="txtUserPasswd" ErrorMessage="密码是必填项！" ValidationGroup="login"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style1">*确认密码</td>
                    <td>
                        <asp:TextBox ID="txtUserPasswdSure" runat="server" CssClass="text" TextMode="Password"></asp:TextBox>
                    </td>
                    <td>
                        <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="txtUserPasswd" ControlToValidate="txtUserPasswdSure" ErrorMessage="两次密码不一样" ValidationGroup="login"/>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style1">*真实姓名</td>
                    <td>
                        <asp:TextBox ID="txtUserName" runat="server" CssClass="text"></asp:TextBox>
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="rfvUserName" runat="server" ControlToValidate="txtUserName" ErrorMessage="姓名是必填项！" ValidationGroup="login"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style1">*性别</td>
                    <td>
                        <asp:RadioButtonList ID="radSex" runat="server" CssClass="text" RepeatDirection="Horizontal">
                            <asp:ListItem Value="1">男</asp:ListItem>
                            <asp:ListItem Value="0">女</asp:ListItem>
                        </asp:RadioButtonList>
                    </td>
                    <td></td>
                </tr>
                <tr>
                    <td class="auto-style1">*身份证号</td>
                    <td>
                        <asp:TextBox ID="txtUserIdentification" runat="server" CssClass="text"></asp:TextBox>
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="rfvUserIdentification" runat="server" ControlToValidate="txtUserIdentification" ErrorMessage="身份证号是必填项！" ValidationGroup="login" />
                    </td>
                </tr>
                <tr>
                    <td class="auto-style1">联系电话</td>
                    <td>
                        <asp:TextBox ID="txtUserTelephone" runat="server" CssClass="text"></asp:TextBox></td>
                    <td>
                        
                    </td>
                </tr>
            </table>
            <asp:Label ID="labError" runat="server" BackColor="Red" Text="*为必填项"></asp:Label>
         </div>
        <br />
        <asp:Button ID="btnRegister" runat="server" Text="遁入阴间" CssClass="Button" OnClick="btnRegister_Click" ValidationGroup="login" />
        <asp:Button ID="btnBack" CssClass="Button" runat="server" Text="返回" OnClick="btnBack_Click" />
    </form>
</body>
</html>