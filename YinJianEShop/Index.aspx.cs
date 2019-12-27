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
        }

        protected void btnCart_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("/User/UserShopCart.aspx");
        }

        protected void btnbuy_Click(object sender, EventArgs e)
        {
            Button buttonBuy = (Button)sender;
            int i = Convert.ToInt32(buttonBuy.CommandArgument.ToString());
        }

        protected void btnAddCart_Click(object sender, EventArgs e)
        {
            Button buttonAddCart = (Button)sender;
            int goodId = Convert.ToInt32(buttonAddCart.CommandArgument.ToString());

            CookieHelper.WriteInCookie(goodId, 1);

        }
    }
}