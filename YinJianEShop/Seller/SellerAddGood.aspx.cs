using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;

namespace YinJianEShop.Seller
{
    public partial class SellerAddGood : System.Web.UI.Page
    {
        eShopDatabaseEntities eShop = new eShopDatabaseEntities();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Session["Seller"]==null)
            {
                this.btnGoodAdd.Visible = false;
            }
        }

        protected void btnGoodAdd_Click(object sender, EventArgs e)
        { 
            //图片上传
            //判断是否有文件上传
            if (uploadImg.HasFile)
            {
                string savePath = Server.MapPath("~/Images/Goods/");

                if (!System.IO.Directory.Exists(savePath))
                {
                    System.IO.Directory.CreateDirectory(savePath);
                }

                //判断文件是否合法 
                //读取合法文件列表
                string[] allowExtension = ConfigurationManager.AppSettings["ImgType"].ToString().Split('|');
                string fileExtension = System.IO.Path.GetExtension(uploadImg.FileName).ToLower();
                bool checkImg = false;
                foreach (string str in allowExtension)
                {
                    if (fileExtension == str)
                    {
                        checkImg = true;
                        break;
                    }
                }
                //上传文件
                if (checkImg)
                {
                    try
                    {
                        this.uploadImg.PostedFile.SaveAs(savePath + uploadImg.FileName);
                        this.labUploadImg.Text = "上传成功！";
                    }
                    catch
                    {
                        this.labUploadImg.Text = "上传失败！";
                    }
                }
                else
                {
                    this.labUploadImg.Text = "文件扩展名不合法";
                }
            }
            GoodsImg goodImg = new GoodsImg();
            goodImg.ImgLevel = 0;
            goodImg.ImgUrl=Server.MapPath("~/Images/Goods/") + this.uploadImg.FileName;

            GoodsInfo good = new GoodsInfo();
            good.GoodName = this.txtGoodName.Text.Trim();
            good.GoodPrice = Convert.ToDecimal(this.txtGoodPrice.Text.Trim());
            good.GoodsImg.Add(goodImg);
            good.Remark = this.txtRemark.Text.Trim();
            good.AddedDate = DateTime.Now;
            good.AdderId = ((Sellers)Session["Seller"]).Id;

            eShop.GoodsInfo.Add(good);
            eShop.SaveChanges();
        }
    }
}