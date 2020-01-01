<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SellerManagement.aspx.cs" Inherits="YinJianEShop.Seller.SellerManagement" %>

<!DOCTYPE html>

<html>
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>卖家管理系统</title>
    <script type="text/javascript" src="/js/jquery-3.4.1.min.js"></script>
    
    <link rel="stylesheet" type="text/css" href="/Style/sellerPage.css" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="divPage">
            <div class="divTitle">
                <div class="divMainTitle">
                    <h1>
                        <img src="/Images/Page/00BB5A67.png" style="height:50%;opacity:0.4;">
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        卖&nbsp;家&nbsp;管&nbsp;理&nbsp;平&nbsp;台
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <img src="/Images/Page/00BB521A.png" style="height:50%;opacity:0.4;" />
                    </h1>
                </div>
                <div class="divLittleTitle">
                    <p>人生何须久睡 死后自会长眠</p>
                </div>
            </div>
        <div class="divSecend">
            <div>
                <asp:Menu ID="SellerMenu" runat="server" ForeColor="#ffffff" Orientation="Horizontal" OnMenuItemClick="SellerMenu_MenuItemClick">
                    <Items>
                        <asp:MenuItem Text="商品管理">
                            <asp:MenuItem Text="新建商品" Value="/Seller/SellerAddGood.aspx"></asp:MenuItem>
                            <asp:MenuItem Text="编辑商品" Value="/Seller/SellerEditGood.aspx"></asp:MenuItem>
                        </asp:MenuItem>
                        <asp:MenuItem Text="订单管理">
                            <asp:MenuItem Text="未发货订单" Value="/Seller/SellerUnsendOrder.aspx"></asp:MenuItem>
                            <asp:MenuItem Text="订单记录" Value="/Seller/SellerAllOrder.aspx"></asp:MenuItem>
                        </asp:MenuItem>
                    </Items>
                </asp:Menu>
            </div>
            <div class="divFrame" >
                <iframe class="iframePage" id="theSellerFrame" width="100%" height="800px" frameborder="0" runat="server">
                    您的浏览器不支持iframe，请升级
                </iframe>
            </div>
        </div>
    </div>
    </form>
</body>
   <script type="text/javascript" src="/js/SellerFrame.js"></script>
</html>