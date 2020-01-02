using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace YinJianEShop.User
{
    public partial class UserShopCart : System.Web.UI.Page
    {
        eShopDatabaseEntities eShop = new eShopDatabaseEntities();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["User"] == null)
            {
                Response.Redirect("/User/UserLogin.aspx");
            }

            if (Request.Cookies["ShoppingCart"] != null)
            {
                
               
                var query = from info in eShop.GoodsInfo
                            join img in eShop.GoodsImg on info.Id equals img.GoodId
                            where img.ImgLevel == 0 
                            select new
                            {
                                Id = info.Id,
                                GoodName = info.GoodName,
                                GoodPrice = info.GoodPrice,
                                /*GoodNum = goodsNum[Array.IndexOf(goodsId, info.Id)],*/
                                //GoodNum= int.Parse( cookie.Values[info.Id.ToString()]),
                                //GoodsPrice = info.GoodPrice * int.Parse(cookie.Values[info.Id.ToString()]),
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
        protected void gvUserCart_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            HttpCookie cookie = Request.Cookies["ShoppingCart"];
            e.Row.Cells[4].Text = cookie.Values[e.Row.Cells[0].Text];
            e.Row.Cells[5].Text = (int.Parse(e.Row.Cells[3].Text) * int.Parse(cookie.Values[e.Row.Cells[0].Text])).ToString();
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
            Response.Redirect("/User/UserGoodOrder.aspx");
        }

        
    }
}