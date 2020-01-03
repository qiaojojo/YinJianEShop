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

        private void SellerUnsendOrder_DataBind()
        {
            var queryUnsendOrder = from order in eShop.OrderState
                                   where order.OrderState1 == 1
                                   select new
                                   {
                                       Id = order.Id,
                                       ImgUrl = order.GoodOrder.FirstOrDefault().GoodsInfo.GoodsImg.Where(img => img.ImgLevel == 0).FirstOrDefault().ImgUrl,
                                       OrderNum = order.OrderNum,
                                       CreateDate = order.CreateDate,
                                       PayDate = order.PayDate,
                                       Address = order.UserShoppingAddress.Address
                                   };

            this.gvGoodOrder.DataSource = queryUnsendOrder.ToList();
            this.gvGoodOrder.DataBind();
        }
        private void SellerUnsendOrder_DataBind(string search)
        {
            var queryUnsendOrder = from order in eShop.OrderState
                                   where order.OrderState1 == 1 && order.OrderNum.Contains(search)
                                   select new
                                   {
                                       Id = order.Id,
                                       ImgUrl = order.GoodOrder.FirstOrDefault().GoodsInfo.GoodsImg.Where(img => img.ImgLevel == 0).FirstOrDefault().ImgUrl,
                                       OrderNum = order.OrderNum,
                                       CreateDate = order.CreateDate,
                                       PayDate = order.PayDate,
                                       Address = order.UserShoppingAddress.Address
                                   };
            this.gvGoodOrder.DataSource = queryUnsendOrder.ToList();
            this.gvGoodOrder.DataBind();
        }

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!Page.IsPostBack)
            {
                SellerUnsendOrder_DataBind();
            }
        }


        protected void btnSearch_Click(object sender, EventArgs e)
        {
            if (this.txtOrderNum.Text.ToString() != null)
            {
                string search = this.txtOrderNum.Text.Trim();
                SellerUnsendOrder_DataBind(search);
            }
            else
            {
                SellerUnsendOrder_DataBind();
            }
        }

        protected void gvGoodOrder_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            TextBox textBox = this.gvGoodOrder.Rows[e.RowIndex].FindControl("txtCourierNum") as TextBox;
            int key =(int) this.gvGoodOrder.DataKeys[e.RowIndex].Value;
            if(textBox.Text!=null)
            {
                var orderState = eShop.OrderState.Find(key);
                orderState.CourierNum = textBox.Text.Trim();
                orderState.SendDate = DateTime.Now;
                orderState.OrderState1 = 2;
                eShop.SaveChanges();
                SellerUnsendOrder_DataBind();
            }
        }
    }
}