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
            if (Session["User"] == null)
            {
                Response.Redirect("/User/UserLogin.aspx");
            }

            if (Request.Cookies["ShoppingCart"] != null)
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
                                GoodsPrice = info.GoodPrice * goodsNum[Array.IndexOf(goodsId, info.Id)],
                                ImgUrl = img.ImgUrl
                            };

                this.gvUserCart.DataSource = query.ToList();
                this.gvUserCart.DataBind();
            }
            else
            {
                this.labMessege.Text = "购物车为空！";
            }
        }

        protected void gvUserCart_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if(e.CommandName=="update")
            {
                TextBox textBox = this.gvUserCart.Rows[Convert.ToInt32(e.CommandArgument)].FindControl("strNum") as TextBox;

                Helper.CookieHelper.ChangeCookie(Convert.ToInt32(e.CommandArgument), int.Parse(textBox.Text.ToString()));

            }
            else if(e.CommandName=="delete")
            {
                Helper.CookieHelper.DeleteCookie(Convert.ToInt32(e.CommandArgument));
            }
            else
            {

            }
        }

        protected void btnBuy_Click(object sender, EventArgs e)
        {
            Response.Redirect("/UserGoodOrder.aspx");
        }
    }
}