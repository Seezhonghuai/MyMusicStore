﻿using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using MusicStoreEntity;
using MusicStoreEntity.UserAndRole;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace MusicStore101.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var context = new EntityDbContext();
            var list = context.Albums.OrderByDescending(x => x.PublisherDate).Take(50).ToList();
            return View(list);
        }
        /// <summary>
        /// 测试登录
        /// </summary>
        /// <param name="username"></param>
        /// <param name="pwd"></param>
        /// <returns></returns>
        public string TestLogin(string username = "messi", string pwd = "123.abc")
        {
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new MusicStoreEntity.EntityDbContext()));
            var user = userManager.Find(username, pwd);
            if (user != null)
            {
                var roleName = "";
                var context = new MusicStoreEntity.EntityDbContext();
                foreach (var role in user.Roles)
                    roleName += (context.Roles.Find(role.RoleId) as ApplicationRole).DisplayName + " ";
                return "登录成功，用户属于:" + roleName;
            }
            else
                return "登录失败";
        }

        /// <summary>
        /// 测试登录
        /// </summary>
        /// <param name="username"></param>
        /// <param name="pwd"></param>
        /// <returns></returns>
        /// 
        //public async Task<ActionResult>Testhack()
        //{
        //    var clinet = new HttpClient();
        //    {
        //        //初始化提交的参数
        //        var values = new List<KeyValuePair<string, string>>();
        //        values.Add(new KeyValuePair<string, string>("UserName", "messi"));
        //        values.Add(new KeyValuePair<string, string>("PassWord", "123.abc"));
        //        var content = new FormUrlEncodedContent(values);
        //        var respnse = await client.PostAsync("http://10.88.91.101:9000/account/login", content);
        //        var html = await respnse.Content.ReadAsStringAsync();
        //        return Json("");
        //    }
        //}
    }
}