using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace YinJianEShop.Helper
{
    static class CookieHelper
    {
        public static void WriteInCookie(int goodId,int goodNum)
        {
            HttpCookie cookie = null;
            if (HttpContext.Current.Request.Cookies["ShoppingCart"] == null)
            {
                cookie = new HttpCookie("ShoppingCart");
            }
            else
            {
                cookie = HttpContext.Current.Request.Cookies["ShoppingCart"];
            }

            //验证添加是否重复
            bool flag = true;//标记在购物车中是否存在本次选择的物品

            //在购物车的Cookies中查找是否存在这次要选择的物品
            foreach (string item in cookie.Values)
            {
                if (item.Split('|')[0] == goodId.ToString())
                {
                    flag = false;
                    break;
                }
            }

            //如果物品不存在则创建
            //如果物品存在则变更数量
            if (flag)
            {
                cookie.Values.Add(goodId.ToString(), goodId + "|" + goodNum + "|");
            }
            else
            {
                int num = int.Parse(cookie.Values[goodId.ToString()].Split('|')[1]);
                cookie.Values.Remove(goodId.ToString());
                cookie.Values.Add(goodId.ToString(), goodId + "|" + num + goodNum + "|");
            }
            //设置过期时间
            cookie.Expires = DateTime.Now.AddDays(7);
            HttpContext.Current.Response.Cookies.Add(cookie);
        }

        public static void ChangeCookie(int goodId,int goodNum)
        {
            HttpCookie cookie = null;
            if (HttpContext.Current.Request.Cookies["ShoppingCart"] == null)
            {
                return;
            }
            else
            {
                cookie = HttpContext.Current.Request.Cookies["ShoppingCart"];
            }

            cookie.Values.Remove(goodId.ToString());
            cookie.Values.Add(goodId.ToString(), goodId + "|" + goodNum + "|");
        }

        public static void DeleteCookie(int goodId)
        {
            HttpCookie cookie = null;
            if (HttpContext.Current.Request.Cookies["ShoppingCart"] == null)
            {
                return;
            }
            else
            {
                cookie = HttpContext.Current.Request.Cookies["ShoppingCart"];
            }

            cookie.Values.Remove(goodId.ToString());
        }
    }
}