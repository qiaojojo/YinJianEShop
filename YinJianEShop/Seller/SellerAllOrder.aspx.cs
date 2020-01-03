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

        private void SellerAllOrder_DataBind()
        {
            var queryUserOrders = from orderState in eShop.OrderState
                                  orderby orderState.OrderState1 ascending
                                  select new
                                  {
                                      Id = orderState.Id,
                                      OrderNum = orderState.OrderNum,
                                      CreateDate = orderState.CreateDate,
                                      PayDate = orderState.PayDate,
                                      SendDate = orderState.SendDate,
                                      UserGetDate = orderState.UserGetDate,
                                      CourierNum = orderState.CourierNum,
                                      Address = orderState.UserShoppingAddress.Address,
                                      OrderStatus = orderState.OrderState1
                                  };
            this.gvAllOrder.DataSource = queryUserOrders.ToList();
            this.gvAllOrder.DataBind();
        }
        private void SellerAllOrder_DataBind(string search)
        {
            var queryUserOrders = from orderState in eShop.OrderState
                                  where orderState.OrderNum.Contains(search)
                                  orderby orderState.OrderState1 ascending
                                  select new
                                  {
                                      Id = orderState.Id,
                                      OrderNum = orderState.OrderNum,
                                      CreateDate = orderState.CreateDate,
                                      PayDate = orderState.PayDate,
                                      SendDate = orderState.SendDate,
                                      UserGetDate = orderState.UserGetDate,
                                      CourierNum = orderState.CourierNum,
                                      Address = orderState.UserShoppingAddress.Address,
                                      OrderStatus = orderState.OrderState1
                                  };
            this.gvAllOrder.DataSource = queryUserOrders.ToList();
            this.gvAllOrder.DataBind();
        }



        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Seller"] == null)
            {
                this.btnSearch.Visible = false;
            }
            else
            {
                if (!Page.IsPostBack)
                {
                    SellerAllOrder_DataBind();
                }
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            if (this.txtSearch.Text.ToString() != null)
            {
                string search = this.txtSearch.Text.Trim();
                SellerAllOrder_DataBind(search);
            }
            else
            {
                SellerAllOrder_DataBind();
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

        protected void gvAllOrder_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            //int OrderId = Convert.ToInt32(this.gvAllOrder.DataKeys[Convert.ToInt32(e.CommandArgument)].Value);
            if (e.CommandName == "status")
            {
                Response.Redirect("/Seller/SellerOrderState.aspx?id=" + e.CommandArgument);
            }
        }
    }
}