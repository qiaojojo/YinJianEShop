using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace YinJianEShop.User
{
    public partial class UserAllOrder : System.Web.UI.Page
    {
        eShopDatabaseEntities eShop = new eShopDatabaseEntities();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["User"] == null)
            {
                Response.Redirect("/User/UserLogin.aspx");
            }
            var queryUserOrders = from orderState in eShop.OrderState
                                  where orderState.UserId == ((Users)Session["User"]).Id
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
                                      OrderStatus=orderState.OrderState1
                                  };
            this.gvGoodOrder.DataSource = queryUserOrders;
            this.gvGoodOrder.DataBind();
        }

        protected void gvGoodOrder_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "status")
            {
                Response.Redirect("/User/UserGoodOrder.aspx?id=" + e.CommandArgument);
            }
        }

        protected void gvGoodOrder_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            
            if(e.Row.Cells[8].Text=="0")
            {
                e.Row.Cells[8].Text = "未付款";
                e.Row.BackColor = System.Drawing.Color.Red;
            }
            else if(e.Row.Cells[8].Text =="1")
            {
                e.Row.Cells[8].Text = "待发货";
                e.Row.BackColor = System.Drawing.Color.Yellow;
            }
            else if(e.Row.Cells[8].Text =="2")
            {
                e.Row.Cells[8].Text = "待确认收货";
                e.Row.BackColor = System.Drawing.Color.Green;
            }
            else if(e.Row.Cells[8].Text =="3")
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