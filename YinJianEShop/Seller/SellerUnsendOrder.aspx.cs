using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace YinJianEShop.Seller
{
    public partial class SellerUnsendOrder : System.Web.UI.Page
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
                if (!Page.IsPostBack)
                {
                    var queryUnsendOrder = from order in eShop.OrderState
                                           where order.OrderState1 == 1
                                           select new
                                           {
                                               OrderId = order.Id,
                                               ImgUrl = order.GoodOrder.FirstOrDefault().GoodsInfo.GoodsImg.Where(img => img.ImgLevel == 0).FirstOrDefault().ImgUrl,
                                               OrderNum = order.OrderNum,
                                               CreateDate = order.CreateDate,
                                               PayDate = order.PayDate,
                                               Address = order.UserShoppingAddress.Address
                                           };

                    this.gvGoodOrder.DataSource = queryUnsendOrder.ToList();
                    this.gvGoodOrder.DataBind();

                }
            }
            
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            if (this.txtOrderNum.Text.ToString() != null)
            {
                var queryUnsendOrder = from order in eShop.OrderState
                                       where order.OrderState1 == 1 && order.OrderNum.Contains( this.txtOrderNum.Text.Trim())
                                       select new
                                       {
                                           OrderId = order.Id,
                                           ImgUrl = order.GoodOrder.FirstOrDefault().GoodsInfo.GoodsImg.Where(img => img.ImgLevel == 0).FirstOrDefault().ImgUrl,
                                           OrderNum = order.OrderNum,
                                           CreateDate = order.CreateDate,
                                           PayDate = order.PayDate,
                                           Address = order.UserShoppingAddress.Address
                                       };
                this.gvGoodOrder.DataSource = queryUnsendOrder;
                this.gvGoodOrder.DataBind();
            }
            else
            {
                var queryUnsendOrder = from order in eShop.OrderState
                                       where order.OrderState1 == 1
                                       select new
                                       {
                                           OrderId = order.Id,
                                           ImgUrl = order.GoodOrder.FirstOrDefault().GoodsInfo.GoodsImg.Where(img => img.ImgLevel == 0).FirstOrDefault().ImgUrl,
                                           OrderNum = order.OrderNum,
                                           CreateDate = order.CreateDate,
                                           PayDate = order.PayDate,
                                           Address = order.UserShoppingAddress.Address
                                       };
                this.gvGoodOrder.DataSource = queryUnsendOrder;
                this.gvGoodOrder.DataBind();
            }
        }

        protected void gvGoodOrder_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            TextBox textBox = this.gvGoodOrder.Rows[e.RowIndex].FindControl("txtCourierNum") as TextBox;
            if(textBox.Text!=null)
            {
                OrderState orderState = eShop.OrderState.Find(e.RowIndex);
                orderState.CourierNum = textBox.Text.Trim();
                orderState.SendDate = DateTime.Now;
                orderState.OrderState1 = 2;
                eShop.OrderState.Attach(orderState);
                eShop.Entry(orderState).State = EntityState.Modified;
                eShop.SaveChanges();
            }
        }
    }
}