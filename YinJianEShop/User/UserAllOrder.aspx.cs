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

        private void UserAllOrder_DataBind()
        {
            int id = ((Users)Session["User"]).Id;
            var queryUserOrders = from orderState in eShop.OrderState
                                  where orderState.UserId == id
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
            this.gvGoodOrder.DataSource = queryUserOrders.ToList();
            this.gvGoodOrder.DataBind();
        }
        private void UserAllOrder_DataBind(string search)
        {
            int id = ((Users)Session["User"]).Id;
            var queryUserOrders = from orderState in eShop.OrderState
                                  where orderState.UserId == id
                                  && orderState.OrderNum.Contains(search)
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
            this.gvGoodOrder.DataSource = queryUserOrders.ToList();
            this.gvGoodOrder.DataBind();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["User"] == null)
            {
                Response.Redirect("/User/UserLogin.aspx");
            }
            if(!Page.IsPostBack)
            {
                UserAllOrder_DataBind();
            }
        }


        protected void btnSearch_Click(object sender, EventArgs e)
        {
            if(this.txtSearch.Text!=null)
            {
                UserAllOrder_DataBind(this.txtSearch.Text.Trim());
            }
        }


        protected void gvGoodOrder_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "status")
            {
                Response.Redirect("/User/UserPayOrder.aspx?id=" + e.CommandArgument);
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