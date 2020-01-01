using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace YinJianEShop.User
{
    public partial class UserPay : System.Web.UI.Page
    {
        eShopDatabaseEntities eShop = new eShopDatabaseEntities();
        int orderId;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["User"] == null)
            {
                Response.Redirect("/User/UserLogin.aspx");
            }

            orderId = int.Parse(Request.QueryString["id"]);

            var queryOrderState = from info in eShop.GoodsInfo
                                  join goodOrder in eShop.GoodOrder on info.Id equals goodOrder.GoodId
                                  join img in eShop.GoodsImg on info.Id equals img.GoodId
                                  where img.ImgLevel == 0
                                    && goodOrder.OrderId == orderId
                                    && goodOrder.OrderState.UserId == ((Users)Session["User"]).Id
                                  select new
                                  {
                                      Id = info.Id,
                                      GoodName = info.GoodName,
                                      GoodPrice = info.GoodPrice,
                                      GoodNum = goodOrder.GoodsNum,
                                      GoodsPrice = info.GoodPrice * goodOrder.GoodsNum,
                                      ImgUrl = img.ImgUrl,
                                      OrderStatus = goodOrder.OrderState.OrderState1
                                  };

            this.gvGoodOrder.DataSource = queryOrderState;
            this.gvGoodOrder.DataBind();


            //计算总价
            decimal sumPrice = 0;
            foreach (var item in queryOrderState)
            {
                sumPrice += (decimal)item.GoodsPrice;
            }
            this.labPriceSum.Text = sumPrice.ToString();

            //判断订单状态显示按钮
            int orderStatus = (int)queryOrderState.FirstOrDefault().OrderStatus;
            if(orderStatus==0)
            {
                this.txtPayNumber.Visible = true;
                this.btnSurePay.Visible = true;
            }
            else if(orderStatus==2)
            {
                this.btnUserGet.Visible = true;
            }


        }

        protected void btnSurePay_Click(object sender, EventArgs e)
        {
            decimal realPay = Convert.ToDecimal(this.txtPayNumber.Text.ToString());
            if(realPay>= Convert.ToDecimal( this.labPriceSum.Text))
            {
                var queryGoodState = from orderState in eShop.OrderState
                                     where orderState.Id == orderId
                                     select orderState;


                OrderState order = queryGoodState.FirstOrDefault();
                order.OrderState1 = 1;
                order.RealPay = realPay;
                order.PayDate = DateTime.Now;

                eShop.OrderState.Attach(order);
                eShop.Entry(order).State = EntityState.Modified;
                eShop.SaveChanges();
            }
        }

        protected void btnUserGet_Click(object sender, EventArgs e)
        {
            var queryGoodState = from orderState in eShop.OrderState
                                 where orderState.Id == orderId
                                 select orderState;


            OrderState order = queryGoodState.FirstOrDefault();
            order.OrderState1 = 3;
            order.UserGetDate = DateTime.Now;

            eShop.OrderState.Attach(order);
            eShop.Entry(order).State = EntityState.Modified;
            eShop.SaveChanges();

        }
    }
}