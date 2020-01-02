using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace YinJianEShop.Seller
{
    public partial class SellerOrderState : System.Web.UI.Page
    {
        eShopDatabaseEntities eShop = new eShopDatabaseEntities();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Request.QueryString["id"]!=null)
            {
                var queryOrderState = from info in eShop.GoodsInfo
                                      join goodOrder in eShop.GoodOrder on info.Id equals goodOrder.GoodId
                                      join img in eShop.GoodsImg on info.Id equals img.GoodId
                                      where img.ImgLevel == 0
                                        && goodOrder.OrderId == int.Parse(Request.QueryString["id"])
                                      select new
                                      {
                                          Id = info.Id,
                                          GoodName = info.GoodName,
                                          GoodPrice = info.GoodPrice,
                                          GoodNum = goodOrder.GoodsNum,
                                          GoodsPrice = info.GoodPrice * goodOrder.GoodsNum,
                                          ImgUrl = img.ImgUrl
                                      };

                var queryReceiver = from order in eShop.OrderState
                                    where order.Id == int.Parse(Request.QueryString["id"])
                                    select new
                                    {
                                        order.OrderState1,
                                        order.UserShoppingAddress.Receiver,
                                        order.UserShoppingAddress.Address,
                                        order.UserShoppingAddress.Telephone
                                    };

                //计算总价
                decimal sumPrice = 0;
                foreach (var item in queryOrderState)
                {
                    sumPrice += (decimal)item.GoodsPrice;
                }

                //判断订单状态
                int intStatus= queryReceiver.FirstOrDefault().OrderState1.Value;

                if (intStatus == 0)
                {
                    this.labStatus.Text = "未付款";

                }
                else if (intStatus == 1)
                {
                    this.labStatus.Text = "待发货";

                }
                else if (intStatus == 2)
                {
                    this.labStatus.Text = "待确认收货";

                }
                else if (intStatus == 3)
                {
                    this.labStatus.Text = "已完成";
                }
                else
                {
                    this.labStatus.Text = null;
                }

                this.labPriceSum.Text = sumPrice.ToString();
                this.labReceiver.Text = queryReceiver.FirstOrDefault().Receiver;
                this.labAddress.Text = queryReceiver.FirstOrDefault().Address;
                this.labTelephone.Text = queryReceiver.FirstOrDefault().Telephone;


                this.gvOrderState.DataSource = queryOrderState;
                this.gvOrderState.DataBind();

            }
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Seller/SellerAllOrder.aspx");
        }
    }
}