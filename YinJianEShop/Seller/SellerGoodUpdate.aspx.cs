using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.Entity;

namespace YinJianEShop.Seller
{
    public partial class SellerGoodUpdate : System.Web.UI.Page
    {
        eShopDatabaseEntities eShop = new eShopDatabaseEntities();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Request.QueryString["id"] != null
                    && eShop.GoodsInfo.Find(int.Parse(Request.QueryString["id"])) != null
                    && Session["Seller"] != null)
                {
                    var goodInfo = eShop.GoodsInfo.Find(int.Parse(Request.QueryString["id"]));

                    this.txtGoodName.Text = goodInfo.GoodName;
                    this.txtGoodPrice.Text = goodInfo.GoodPrice.ToString();
                    this.imgGoodImg.Src = goodInfo.GoodsImg.Where(img => img.ImgLevel == 0)
                                                                .FirstOrDefault()
                                                                .ImgUrl;
                    this.txtRemark.Text = goodInfo.Remark;
                }
                else
                {
                    this.btnGoodUpdate.Visible = false;
                    this.labMessenge.Text = "页面加载错误";
                }
            }
            
            if(this.checkUploadImg.Checked==false)
            {
                this.uploadImg.Visible = false;
                this.rfvUploadImg.Visible = false;
            }
        }


        protected void btnGoodUpdate_Click(object sender, EventArgs e)
        {
            var goodInfo = eShop.GoodsInfo.Find(int.Parse(Request.QueryString["id"]));

            goodInfo.GoodName = this.txtGoodName.Text.Trim();
            goodInfo.GoodPrice = Convert.ToDecimal(this.txtGoodPrice.Text.Trim());

            //如果checkbox选中则更新图片
            if (this.checkUploadImg.Checked == true)
            {
                //上传图片前的检查
                if (uploadImg.HasFile)
                {
                    string savePath = Server.MapPath("~/Images/Goods/");

                    //检查文件保存路径是否存在
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
                            this.imgGoodImg.Src = savePath + uploadImg.FileName;
                            this.labUploadImg.Text = "上传成功！";
                            
                            //更新图片链接
                            goodInfo.GoodsImg.Where(img => img.ImgLevel == 0).FirstOrDefault().ImgUrl = "/Images/Goods/" + this.uploadImg.FileName;
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
            }

            goodInfo.Remark = this.txtRemark.Text.Trim();
            goodInfo.AddedDate = DateTime.Now;

            try
            {
                eShop.SaveChanges();
                this.labMessenge.Text = "商品数据更新成功！";
            }
            catch
            {
                this.labMessenge.Text = "更新发生错误，数据未改变！";
            }
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Seller/SellerEditGood.aspx");
        }
    }
}