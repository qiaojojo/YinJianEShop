<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="UserAddAddress.aspx.cs" Inherits="YinJianEShop.User.UserAddAddress" %>

<asp:Content ContentPlaceHolderID="head" ID="goodsHead" runat="server">
    <link rel="stylesheet" type="text/css" href="/Style/addAddress.css">
</asp:Content>


<asp:Content ContentPlaceHolderID="MainContent" ID="MainPage" runat="server">
    <div class="divMenu">
        <a href="/Index.aspx">返回首页</a>
        <a href="/User/UserShopCart.aspx"><img Class=".shoppingCart" src="/Images/Page/Cart.png" /></a>
    </div>
    <div class="divUserAddress">
        <asp:GridView ID="gvAddress" CssClass="gvAddress" runat="server" OnRowDeleting="gvAddress_RowDeleting" DataKeyNames="Id">
        <Columns>
            <asp:BoundField DataField="Receiver" HeaderText="收件人" />
            <asp:BoundField DataField="Telephone" HeaderText="联系方式" />
            <asp:BoundField DataField="Address" HeaderText="地址" />
            <asp:TemplateField HeaderText="操作">
                <ItemTemplate>
                    <asp:LinkButton ID="lbtnDelete" runat="server" CommandName="Delete" OnClientClick="return confirm('确认要删除吗？');">删除</asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
        </asp:GridView>
        <br /><br />

        <div>
            <h2>新建收件地址</h2>
            <table>
            <tr>
                <td>收件人</td>
                <td>
                    <asp:TextBox ID="txtReceiver" runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="rfvReceiver" ForeColor="Red" runat="server" ControlToValidate="txtReceiver" ErrorMessage="收件人是必填项！"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>联系方式</td>
                <td>
                    <asp:TextBox ID="txtTelephone" runat="server"></asp:TextBox>
                </td>
                <td>
                     <asp:RequiredFieldValidator ID="rfvTelephone" ForeColor="Red" runat="server" ControlToValidate="txtTelephone" ErrorMessage="电话号码是必填项！"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>地址</td>
                <td>
                    <asp:TextBox ID="txtAddress" runat="server"></asp:TextBox>
                </td>
                <td>
                     <asp:RequiredFieldValidator ID="rfvAddress" ForeColor="Red" runat="server" ControlToValidate="txtAddress" ErrorMessage="地址是必填项！"></asp:RequiredFieldValidator>
                </td>
            </tr>
            </table>
        </div>
        <asp:Button ID="btnAddAddress" CssClass="button" runat="server" Text="添加地址" OnClick="btnAddAddress_Click" />
    </div>
</asp:Content>


