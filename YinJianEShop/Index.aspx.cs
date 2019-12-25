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
                eShopDatabaseEntities eShop = new eShopDatabaseEntities();

                var query = from info in eShop.GoodsInfo
                            join img in eShop.GoodsImg on info.Id equals img.GoodId
                            where img.ImgLevel == 0
                            select new
                            {
                                info.Id,
                                info.GoodName,
                                info.GoodPrice,
                                img.ImgUrl
                            };
                //将查询结果循环加载到网页上
                foreach (var good in query)
                {
                    this.divGoodList.InnerHtml += "<div class='divGood'>";
                    this.divGoodList.InnerHtml += "<p><img src='"+good.ImgUrl+"' alt='"+good.GoodName+"'/></p><br />";
                    this.divGoodList.InnerHtml += "<h2>" + good.GoodName + "</h2>";
                    this.divGoodList.InnerHtml += "<p> 价格: " + good.GoodPrice + "元 </p>";
                    this.divGoodList.InnerHtml += "<button class='add-to-cart' type='button' onclick=''>加入购物车</button>";
                    this.divGoodList.InnerHtml += "</div>";
                }
            }
        }
    }
}