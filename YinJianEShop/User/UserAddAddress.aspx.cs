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

        private void UserAddress_DataBind()
        {
            int userId = ((Users)Session["User"]).Id;
            var queryAddress = from address in eShop.UserShoppingAddress
                               where address.UserId == userId
                               select new
                               {
                                   Id=address.Id,
                                   Receiver = address.Receiver,
                                   Telephone = address.Telephone,
                                   Address = address.Address
                               };
            this.gvAddress.DataSource = queryAddress.ToList();
            this.gvAddress.DataBind();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["User"] == null)
            {
                Response.Redirect("/User/UserLogin.aspx");
            }
            if(!Page.IsPostBack)
            {
                UserAddress_DataBind();
            }
        }

        protected void gvAddress_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int id = (int)e.Keys["Id"];
            var queryAddress = from address in eShop.UserShoppingAddress
                               where address.Id == id
                               select address;

            eShop.UserShoppingAddress.Remove(queryAddress.FirstOrDefault());
            eShop.SaveChanges();
            UserAddress_DataBind();
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
            UserAddress_DataBind();
        }

        
    }
}