using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace YinJianEShop.User
{
    public partial class UserShopCart : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            HttpCookie cookie = Request.Cookies["ShoppingCart"];
            eShopDatabaseEntities eShop = new eShopDatabaseEntities();

            int[] goodsId = { };
            int[] goodsNum = { };

            foreach (string item in cookie.Values)
            {
                goodsId[goodsId.Length] = int.Parse(item.Split('|')[0]);
                goodsNum[goodsNum.Length] = int.Parse(item.Split('|')[1]);
            }

            var query = from info in eShop.GoodsInfo
                        join img in eShop.GoodsImg on info.Id equals img.GoodId
                        where img.ImgLevel == 0 && goodsId.Equals(info.Id)
                        select new
                        {
                            Id = info.Id,
                            GoodName = info.GoodName,
                            GoodPrice = info.GoodPrice,
                            GoodNum = goodsNum[Array.IndexOf(goodsId, info.Id)],
                            GoodsPrece = info.GoodPrice * goodsNum[Array.IndexOf(goodsId, info.Id)],
                            ImgUrl = img.ImgUrl
                        };

            this.gvUserCart.DataSource = query.ToList();
            this.gvUserCart.DataBind();
        }
    }
}