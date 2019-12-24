using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace YinJianEShop.Seller
{
    public partial class SellerLogin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string strSellerNum = this.txtSellerNum.Text.Trim();
            string strSellerPasswd = this.txtSellerPasswd.Text.Trim();

            if (strSellerNum == "" || strSellerNum == null)
            {
                this.labError.Text = "用户名不能为空！";
                return;
            }
            if (strSellerPasswd == "" || strSellerPasswd == null)
            {
                this.labError.Text = "密码不能为空！";
                return;
            }

            eShopDatabaseEntities eShop = new eShopDatabaseEntities();
            string passwdMd5 = pwdMD5.PasswdMD5Locker.MD5Encrypt(strSellerPasswd);

            var query = from sellers in eShop.Sellers
                        where sellers.SellerNum.Equals(strSellerNum) &&
                            sellers.SellerPasswd.Equals(passwdMd5)
                        select new
                        {
                            sellers.Id,
                            sellers.SellerNum,
                            sellers.SellerPasswd
                        };

            if(query.Count()>0)
            {
                Sellers seller = new Sellers();
                seller.Id = query.FirstOrDefault().Id;
                seller.SellerNum = query.FirstOrDefault().SellerNum;
                seller.SellerPasswd = query.FirstOrDefault().SellerPasswd;
                Session["Seller"] = seller;
                Response.Redirect("~/Seller/SellerManagement.aspx");
            }
            else
            {
                this.labError.Text = "用户名或密码错误！";
            }
        }
    }
}