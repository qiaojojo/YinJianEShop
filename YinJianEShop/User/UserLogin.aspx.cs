using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace YinJianEShop.User
{
    public partial class UserLogin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string strUserNum= this.txtUserNum.Text.Trim();
            string strUserPasswd = this.txtUserPasswd.Text.Trim();

            if (strUserNum == "" || strUserNum == null)
            {
                this.labError.Text = "用户名不能为空！";
                return;
            }
            if (strUserPasswd == "" || strUserPasswd == null)
            {
                this.labError.Text = "密码不能为空！";
                return;
            }

            eShopDatabaseEntities eShop = new eShopDatabaseEntities();
            
            string passwdMd5 = pwdMD5.PasswdMD5Locker.MD5Encrypt(strUserPasswd);

            var query = from user in eShop.Users
                        where user.UserNum.Equals(strUserNum) &&
                            user.UserPasswd.Equals(passwdMd5)
                        select user;


            if(query.Count()>0)
            {
                Users user = query.FirstOrDefault();
                Session["User"] =user;
                Response.Redirect("~/Index.aspx");
            }
            else
            {
                this.labError.Text = "用户名或密码错误！";
            }
            
        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/User/UserRegister.aspx");
        }
    }
}