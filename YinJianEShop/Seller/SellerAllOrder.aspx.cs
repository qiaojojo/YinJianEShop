using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace YinJianEShop.Seller
{
    public partial class SellerAllOrder : System.Web.UI.Page
    {
        eShopDatabaseEntities eShop = new eShopDatabaseEntities();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Seller"] == null)
            {
                this.btnSearch.Visible = false;
            }
            else
            {
                var queryUserOrders = from orderState in eShop.OrderState
                                      orderby orderState.OrderState1 ascending
                                      select new
                                      {
                                          OrderId = orderState.Id,
                                          OrderNum = orderState.OrderNum,
                                          CreateDate = orderState.CreateDate,
                                          PayDate = orderState.PayDate,
                                          SendDate = orderState.SendDate,
                                          UserGetDate = orderState.UserGetDate,
                                          CourierNum = orderState.CourierNum,
                                          Address = orderState.UserShoppingAddress.Address,
                                          OrderStatus = orderState.OrderState1
                                      };
                this.gvAllOrder.DataSource = queryUserOrders;
                this.gvAllOrder.DataBind();
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            if (this.txtSearch.Text.ToString() != null)
            {
                var queryUserOrders = from orderState in eShop.OrderState
                                      where orderState.OrderNum.Contains(this.txtSearch.Text.Trim())
                                      orderby orderState.OrderState1 ascending
                                      select new
                                      {
                                          OrderId = orderState.Id,
                                          OrderNum = orderState.OrderNum,
                                          CreateDate = orderState.CreateDate,
                                          PayDate = orderState.PayDate,
                                          SendDate = orderState.SendDate,
                                          UserGetDate = orderState.UserGetDate,
                                          CourierNum = orderState.CourierNum,
                                          Address = orderState.UserShoppingAddress.Address,
                                          OrderStatus = orderState.OrderState1
                                      };
                this.gvAllOrder.DataSource = queryUserOrders;
                this.gvAllOrder.DataBind();
            }
            else
            {
                var queryUserOrders = from orderState in eShop.OrderState
                                      orderby orderState.OrderState1 ascending
                                      select new
                                      {
                                          OrderId = orderState.Id,
                                          OrderNum = orderState.OrderNum,
                                          CreateDate = orderState.CreateDate,
                                          PayDate = orderState.PayDate,
                                          SendDate = orderState.SendDate,
                                          UserGetDate = orderState.UserGetDate,
                                          CourierNum = orderState.CourierNum,
                                          Address = orderState.UserShoppingAddress.Address,
                                          OrderStatus = orderState.OrderState1
                                      };
                this.gvAllOrder.DataSource = queryUserOrders;
                this.gvAllOrder.DataBind();
            }
        }

        protected void gvAllOrder_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.Cells[8].Text == "0")
            {
                e.Row.Cells[8].Text = "未付款";
                e.Row.BackColor = System.Drawing.Color.Red;
            }
            else if (e.Row.Cells[8].Text == "1")
            {
                e.Row.Cells[8].Text = "待发货";
                e.Row.BackColor = System.Drawing.Color.Yellow;
            }
            else if (e.Row.Cells[8].Text == "2")
            {
                e.Row.Cells[8].Text = "待确认收货";
                e.Row.BackColor = System.Drawing.Color.Green;
            }
            else if (e.Row.Cells[8].Text == "3")
            {
                e.Row.Cells[8].Text = "已完成";
            }
            else
            {
                e.Row.Cells[8].Text = null;
            }
        }
    }
}