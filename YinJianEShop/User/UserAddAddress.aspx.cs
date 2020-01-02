using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace YinJianEShop.User
{
    public partial class UserAddAddress : System.Web.UI.Page
    {
        eShopDatabaseEntities eShop = new eShopDatabaseEntities();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["User"] == null)
            {
                Response.Redirect("/User/UserLogin.aspx");
            }
            var queryAddress = from address in eShop.UserShoppingAddress
                               where address.UserId == ((Users)Session["User"]).Id
                               select address;
            this.gvAddress.DataSource = queryAddress;
            this.gvAddress.DataBind();
        }

        protected void gvAddress_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            var queryAddress = from address in eShop.UserShoppingAddress
                               where address.Id == e.RowIndex
                               select address;

            eShop.UserShoppingAddress.Remove(queryAddress.FirstOrDefault());
            eShop.SaveChanges();
        }

        protected void btnAddAddress_Click(object sender, EventArgs e)
        {
            UserShoppingAddress address = new UserShoppingAddress();
            address.Receiver = this.txtReceiver.Text.Trim();
            address.Telephone = this.txtTelephone.Text.Trim();
            address.Address = this.txtAddress.Text.Trim();
            address.UserId = ((Users)Session["User"]).Id;

            eShop.UserShoppingAddress.Add(address);
            eShop.SaveChanges();
        }

        
    }
}