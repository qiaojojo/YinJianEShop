using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

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
                //将查询结果循环加载到网页上
                //foreach (var good in query)
                //{
                //    this.divGoodList.InnerHtml += @"<div class='divGood'>";
                //    this.divGoodList.InnerHtml += "<p><a href='/GoodShow.aspx?id=" + good.Id + "'><img src='" + good.ImgUrl + "' alt='" + good.GoodName + "'/></a></p><br />";
                //    this.divGoodList.InnerHtml += "<h2>" + good.GoodName + "</h2>";
                //    this.divGoodList.InnerHtml += "<p> 价格: " + good.GoodPrice + "元 </p>";
                //    this.divGoodList.InnerHtml += "<button class='add-to-cart' type='button'  >加入购物车</button>";
                //    this.divGoodList.InnerHtml += "</div>";
                //}
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

        }

        protected void btnAddCart_Click(object sender, EventArgs e)
        {
              

        }
    }
}