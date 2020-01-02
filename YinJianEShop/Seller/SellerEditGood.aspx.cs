using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace YinJianEShop.Seller
{
    public partial class SellerEditGood : System.Web.UI.Page
    {
        eShopDatabaseEntities eShop = new eShopDatabaseEntities();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Seller"] != null)
            {
                var query = from goodInfo in eShop.GoodsInfo
                            join img in eShop.GoodsImg on goodInfo.Id equals img.GoodId
                            where img.ImgLevel == 0
                            select new
                            {
                                Id = goodInfo.Id,
                                ImgUrl = img.ImgUrl,
                                GoodName = goodInfo.GoodName,
                                GoodPrice = goodInfo.GoodPrice,
                                AddedDate = goodInfo.AddedDate,
                                SellerName = goodInfo.Sellers.SellerName
                            };

                this.gvEditGood.DataSource = query.ToList();
                this.gvEditGood.DataBind();
            }
        }

        protected void gvEditGood_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            var goodsImg = eShop.GoodsImg.Where(img => img.GoodId == (int)e.Keys["Id"]);
            var goodsInfo = eShop.GoodsInfo.Find((int)e.Keys["Id"]);
            foreach(GoodsImg img in goodsImg)
            {
                eShop.GoodsImg.Remove(img);
            }
            eShop.GoodsInfo.Remove(goodsInfo);
            eShop.SaveChanges();
        }

        protected void gvEditGood_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            Response.Redirect("/Seller/SellerGoodUpdate.aspx?id=" + (int)e.Keys["Id"]);
        }
    }
}