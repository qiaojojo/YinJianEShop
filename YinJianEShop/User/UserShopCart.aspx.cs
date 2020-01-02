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

        //读取cookie中的商品 加载表单
        private void UserCart_DataBind()
        {
            if (Request.Cookies["ShoppingCart"] != null)
            {
                string[] keys = Request.Cookies["ShoppingCart"].Values.AllKeys;

                var query = from info in eShop.GoodsInfo
                            join img in eShop.GoodsImg on info.Id equals img.GoodId
                            where img.ImgLevel == 0 && keys.Any(str => str == info.Id.ToString())
                            select new
                            {
                                Id = info.Id,
                                GoodName = info.GoodName,
                                GoodPrice = info.GoodPrice,
                                ImgUrl = img.ImgUrl
                            };

                this.gvUserCart.DataSource = query.ToList();
                this.gvUserCart.DataBind();

                if (query.Count() < 1)
                {
                    this.labMessege.Text = "购物车为空！";
                }
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["User"] == null)
            {
                Response.Redirect("/User/UserLogin.aspx");
            }
            if (!Page.IsPostBack)
            {
                UserCart_DataBind();
            }
        }
        
        //读取cookie中的商品数量 计算商品的价格
        protected void gvUserCart_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            HttpCookie cookie = Request.Cookies["ShoppingCart"];

            //判断此行是否为数据行
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label labGoodNum = e.Row.FindControl("labGoodNum") as Label;
                Label labGoodsPrice = e.Row.FindControl("labGoodsPrice") as Label;
                labGoodNum.Text = cookie.Values[e.Row.Cells[0].Text];
                labGoodsPrice.Text = (int.Parse(e.Row.Cells[3].Text) * int.Parse(cookie.Values[e.Row.Cells[0].Text])).ToString();
            }
        }

        protected void gvUserCart_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            TextBox textBox = this.gvUserCart.Rows[e.RowIndex].FindControl("txtNum") as TextBox;

            Helper.CookieHelper.ChangeCookie((int)e.Keys["Id"], int.Parse(textBox.Text.ToString()));

            UserCart_DataBind();
        }

        protected void gvUserCart_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            Helper.CookieHelper.DeleteCookie(Convert.ToInt32(e.Keys["Id"]));

            UserCart_DataBind();
        }

        protected void btnBuy_Click(object sender, EventArgs e)
        {
            Response.Redirect("/User/UserGoodOrder.aspx");
        }
    }
}