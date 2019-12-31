﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace YinJianEShop.User
{
    public partial class UserGoodOrder : System.Web.UI.Page
    {
         eShopDatabaseEntities eShop = new eShopDatabaseEntities();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["User"]==null)
            {
                Response.Redirect("/User/UserLogin.aspx");
            }
            if(Request.Cookies["ShoppingCart"]==null)
            {
                Response.Redirect("/Index.aspx");
            }
            

            //eShopDatabaseEntities eShop = new eShopDatabaseEntities();

            //加载收件人地址
            var queryAddress = from userShoppingAddress in eShop.UserShoppingAddress
                               where userShoppingAddress.UserId == ((Users)Session["User"]).Id
                               select new
                               {
                                   AddressId = userShoppingAddress.Id,
                                   Receiver = userShoppingAddress.Receiver,
                                   Telephone = userShoppingAddress.Telephone,
                                   Address = userShoppingAddress.Address
                               };
            foreach (var item in queryAddress)
            {
                this.rblUserAddress.Items.Add(
                    new ListItem(
                        item.Receiver + " " + item.Telephone + "  " + item.Address,
                        item.AddressId.ToString()
                    )
                );
            }

            //加载商品清单
            int[] goodsId = { };
            int[] goodsNum = { };

            foreach (string item in Request.Cookies["ShoppingCart"].Values)
            {
                goodsId[goodsId.Length] = int.Parse(item.Split('|')[0]);
                goodsNum[goodsNum.Length] = int.Parse(item.Split('|')[1]);
            }

            var queryGoodOrder = from info in eShop.GoodsInfo
                                 join img in eShop.GoodsImg on info.Id equals img.GoodId
                                 where img.ImgLevel == 0 && goodsId.Equals(info.Id)
                                 select new
                                 {
                                     Id = info.Id,
                                     GoodName = info.GoodName,
                                     GoodPrice = info.GoodPrice,
                                     GoodNum = goodsNum[Array.IndexOf(goodsId, info.Id)],
                                     GoodsPrice = info.GoodPrice * goodsNum[Array.IndexOf(goodsId, info.Id)],
                                     ImgUrl = img.ImgUrl
                                 };
            this.gvUserGoodOrder.DataSource = queryGoodOrder;
            this.gvUserGoodOrder.DataBind();

            //计算总价
            decimal sumPrice=0;
            foreach(var item in queryGoodOrder)
            {
                sumPrice +=(decimal) item.GoodsPrice;
            }
            this.labPriceSum.Text = sumPrice.ToString();
        }

        protected void btnPostOrder_Click(object sender, EventArgs e)
        {
            if (this.rblUserAddress.SelectedValue != null)
            {
               

                //创建订单对象
                OrderState order = new OrderState();
                order.OrderNum = DateTime.Now.ToString("yyyyMMddhhmmss") + ((Users)Session["User"]).Id;
                order.CreateDate = DateTime.Now;
                order.OrderState1 = 0;
                order.AddressId = int.Parse(this.rblUserAddress.SelectedValue);

                //创建商品订单对象
                GoodOrder goodOrder;
                foreach (string item in Request.Cookies["ShoppingCart"].Values)
                {
                    goodOrder = new GoodOrder();
                    goodOrder.GoodId = int.Parse(item.Split('|')[0]);
                    goodOrder.GoodsNum = int.Parse(item.Split('|')[1]);
                    order.GoodOrder.Add(goodOrder);
                }

                //添加用户订单
                var queryAddUserOrder = from user in eShop.Users
                                        where user.Id == ((Users)Session["User"]).Id
                                        select user;
                queryAddUserOrder.FirstOrDefault().OrderState.Add(order);
                eShop.SaveChanges();

                //清除所有购物车cookie
                Helper.CookieHelper.RemoveCookie();



                Response.Redirect("/User/UserPayOrder.aspx?id="+order.Id);
            }
            else
            {
                this.labMessege.Text = "请选择收货地址！";
            }
        }
    }
}