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

            if (cookie.Values[goodId.ToString()] != null)
            {
                flag = false;
            }

            //如果物品不存在则创建
            //如果物品存在则变更数量
            if (flag)
            {
                cookie.Values.Add(goodId.ToString(), goodNum.ToString());
            }
            else
            {
                int num = int.Parse(cookie.Values[goodId.ToString()]);
                cookie.Values.Remove(goodId.ToString());
                cookie.Values.Add(goodId.ToString(), (num + goodNum).ToString());
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
            cookie.Values.Add(goodId.ToString(), goodNum.ToString());

            cookie.Expires = DateTime.Now.AddDays(7);
            HttpContext.Current.Response.AppendCookie(cookie);
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
            HttpContext.Current.Response.AppendCookie(cookie);
        }

        public static void RemoveCookie()
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
            //设置cookie过期时间为立即
            cookie.Expires = DateTime.Now;
            HttpContext.Current.Response.AppendCookie(cookie);
        }
    }
}