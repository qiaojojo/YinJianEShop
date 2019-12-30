using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace YinJianEShop.User
{
    public partial class UserPay : System.Web.UI.Page
    {
        eShopDatabaseEntities eShop = new eShopDatabaseEntities();
        protected void Page_Load(object sender, EventArgs e)
        {
            int orderId = int.Parse(Request.QueryString["id"]);

            var queryOrderState = from orderState in eShop.OrderState
                                  where orderState.Id == orderId && orderState.UserId == ((Users)Session["User"]).Id
                                  select orderState;

            
        }
    }
}