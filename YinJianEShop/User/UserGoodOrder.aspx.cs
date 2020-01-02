using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace YinJianEShop.User
{
    public partial class UserGoodOrder : System.Web.UI.Page
    {
        eShopDatabaseEntities eShop = new eShopDatabaseEntities();

        //加载收件人地址
        private void UserGoodOrder_Address()
        {
            int userid = ((Users)Session["User"]).Id;
            var queryAddress = from userShoppingAddress in eShop.UserShoppingAddress
                               where userShoppingAddress.UserId == userid
                               select new
                               {
                                   AddressId = userShoppingAddress.Id,
                                   Receiver = userShoppingAddress.Receiver,
                                   Telephone = userShoppingAddress.Telephone,
                                   Address = userShoppingAddress.Address
                               };
            //将地址载入RadioButton
            foreach (var item in queryAddress)
            {
                this.rblUserAddress.Items.Add(
                    new ListItem(
                        item.Receiver + " " + item.Telephone + "  " + item.Address,
                        item.AddressId.ToString()
                    )
                );
            }
        }

        //加载订单信息
        private void UserGoodOrder_DataBind()
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

                this.gvUserGoodOrder.DataSource = query.ToList();
                this.gvUserGoodOrder.DataBind();

                
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["User"] == null)
            {
                Response.Redirect("/User/UserLogin.aspx");
            }
            if (Request.Cookies["ShoppingCart"] == null)
            {
                Response.Redirect("/Index.aspx");
            }
            if (!Page.IsPostBack)
            {
                //加载收件人地址
                UserGoodOrder_Address();

                //加载商品清单
                UserGoodOrder_DataBind();
            }
        }

        //计算总价
        protected void gvUserGoodOrder_RowDataBound(object sender, GridViewRowEventArgs e)
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

        protected void btnPostOrder_Click(object sender, EventArgs e)
        {
            if (this.rblUserAddress.SelectedValue != null)
            {
                //创建订单对象
                OrderState order = new OrderState();
                order.OrderNum = DateTime.Now.ToString("yyyyMMddhhmmss") + ((Users)Session["User"]).Id;
                order.CreateDate = DateTime.Now;
                order.OrderState1 = 0;
                order.AddressId = int.Parse(this.rblUserAddress.SelectedValue);
                

                //创建商品订单对象
                string[] keys = Request.Cookies["ShoppingCart"].Values.AllKeys;
                foreach (string item in keys)
                {
                    GoodOrder goodOrder = new GoodOrder()
                    {
                        GoodId = int.Parse(item),
                        GoodsNum = int.Parse(Request.Cookies["ShoppingCart"].Values[item])
                    };
                    order.GoodOrder.Add(goodOrder);
                }

                //添加用户订单
                int userid = ((Users)Session["User"]).Id;
                var queryAddUserOrder = from user in eShop.Users
                                        where user.Id == userid
                                        select user;
                queryAddUserOrder.FirstOrDefault().OrderState.Add(order);
                eShop.SaveChanges();

                //清除所有购物车cookie
                Helper.CookieHelper.RemoveCookie();

                //软到支付页面
                Response.Redirect("/User/UserPayOrder.aspx?id=" + order.Id);
            }
            else
            {
                this.labMessege.Text = "请选择收货地址！";
            }
        }

        protected void lbtnAddAddress_Click(object sender, EventArgs e)
        {
            Response.Redirect("/User/UserAddAddress.aspx");
        }
    }
}