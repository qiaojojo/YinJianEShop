using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace YinJianEShop.Seller
{
    public partial class SellerManagement : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void SellerMenu_MenuItemClick(object sender, MenuEventArgs e)
        {
            //Response.Write(this.SellerMenu.SelectedValue);
            this.theSellerFrame.Src = this.SellerMenu.SelectedValue;
        }
    }
}