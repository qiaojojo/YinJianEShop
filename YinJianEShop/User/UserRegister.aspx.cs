using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace YinJianEShop.User
{
    public partial class UserRegister : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            eShopDatabaseEntities eShop = new eShopDatabaseEntities();

            var query = from users in eShop.Users
                        where users.UserNum.Equals(this.txtUserNum.Text.Trim())
                        select users.UserNum;

            if (query.Count() == 0)
            {
                Users user = new Users();
                user.UserNum = this.txtUserNum.Text.Trim();

                string passwdMD5 = pwdMD5.PasswdMD5Locker.MD5Encrypt(this.txtUserPasswd.Text.Trim());
                if (pwdMD5.PasswdMD5Locker.MD5Verify(this.txtUserPasswd.Text.Trim(), passwdMD5))
                    user.UserPasswd = passwdMD5;

                user.UserName = this.txtUserName.Text.Trim();
                if (this.radSex.SelectedValue == "1")
                    user.Gender = true;
                else
                    user.Gender = false;

                user.Identification = this.txtUserIdentification.Text.Trim();
                user.Telephone = this.txtUserTelephone.Text.Trim();

                eShop.Users.Add(user);
                eShop.SaveChanges();

                Response.Redirect("~/User/UserLogin.aspx");
            }
            else
            {
                this.labError.Text = "账户已存在！";
            }
        }
    }
}