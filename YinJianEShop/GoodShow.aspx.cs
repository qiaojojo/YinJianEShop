using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using YinJianEShop.Helper;

namespace YinJianEShop
{
    public partial class GoodShow : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Request.QueryString["id"] != null)
                {
                    int goodId = Int32.Parse(Request.QueryString["id"].ToString());

                    eShopDatabaseEntities eShop = new eShopDatabaseEntities();

                    var query = from info in eShop.GoodsInfo
                                join img in eShop.GoodsImg on info.Id equals img.GoodId
                                join seller in eShop.Sellers on info.AdderId equals seller.Id
                                where img.ImgLevel == 0 && info.Id == goodId
                                select new
                                {
                                    GoodName = info.GoodName,
                                    GoodPrice = info.GoodPrice,
                                    AddedDate = info.AddedDate,
                                    GoodImg = img.ImgUrl,
                                    Adder = seller.SellerName,
                                    Remark = info.Remark
                                };
                    
                    this.FormViewItem.DataSource = query.ToList();
                    this.FormViewItem.DataBind();
                }
            }
        }

        protected void btnAddCart_Click(object sender, EventArgs e)
        {
            if (Session["User"] == null)
            {
                Response.Redirect("/User/UserLogin.aspx");
            }
            int goodId = int.Parse(Request.QueryString["id"].ToString());

            CookieHelper.WriteInCookie(goodId, 1);
        }
    }
}