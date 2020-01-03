using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using YinJianEShop.Helper;

namespace YinJianEShop
{
    public partial class Index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                //加载页面商品
                eShopDatabaseEntities eShop = new eShopDatabaseEntities();

                var query = from info in eShop.GoodsInfo
                            join img in eShop.GoodsImg on info.Id equals img.GoodId
                            where img.ImgLevel == 0
                            select new
                            {
                                Id=info.Id,
                                GoodName=info.GoodName,
                                GoodPrice=info.GoodPrice,
                                ImgUrl=img.ImgUrl
                            };


                this.lvGoodList.DataSource = query.ToList();
                this.lvGoodList.DataBind();
                
            }
            if(Session["User"]!=null)
            {
                this.lbtnAdminLogin.Visible = false;
                this.lbtnLogin.Visible = false;
                this.lbtnRegister.Visible = false;
                this.lbtnUserOrder.Visible = true;
                this.lbtnAddress.Visible = true;
                this.btnCart.Visible = true;

                this.labHello.Text = "你好！用户 " + ((Users)Session["User"]).UserName;
            }
        }

        protected void btnAddCart_Click(object sender, EventArgs e)
        {
            if(Session["User"]==null)
            {
                Response.Redirect("/User/UserLogin.aspx");
            }
            Button buttonAddCart = (Button)sender;
            int goodId = Convert.ToInt32(buttonAddCart.CommandArgument.ToString());

            CookieHelper.WriteInCookie(goodId, 1);

        }

        protected void lbtnLogin_Click(object sender, EventArgs e)
        {
            Response.Redirect("/User/UserLogin.aspx");
        }
        protected void lbtnRegister_Click(object sender, EventArgs e)
        {
            Response.Redirect("/User/UserRegister.aspx");
        }
        protected void lbtnUserOrder_Click(object sender, EventArgs e)
        {
            Response.Redirect("/User/UserAllOrder.aspx");
        }
        protected void lbtnAddress_Click(object sender, EventArgs e)
        {
            Response.Redirect("/User/UserAddAddress.aspx");
        }
        protected void btnCart_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("/User/UserShopCart.aspx");
        }
        protected void lbtnAdminLogin_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Seller/SellerLogin.aspx");
        }
    }
}