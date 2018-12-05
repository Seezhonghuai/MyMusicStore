﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MusicStore101.ViewModels
{
    /// <summary>
    /// 注册的视图模型
    /// </summary>
    public class RegisterViewModel
    {
        [Required(ErrorMessage ="用户名不能为空")]
        [Display(Name ="登录名")]
        public string UerName { get; set; }

        [Required(ErrorMessage = "姓名名不能为空")]
        [Display(Name = "姓名")]
        public string Fullname { get; set; }

        [Required(ErrorMessage = "邮箱不能为空")]
        [Display(Name = "邮箱")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "密码不能为空")]
        [Display(Name = "密码")]
        [DataType(DataType.Password)]
        [StringLength(20,ErrorMessage ="{0}长度不能小于{2}位",MinimumLength =6)]
        public string PassWord { get; set; }

      
        [Display(Name = "确认密码")]
        [DataType(DataType.Password)]
        [Compare("PassWord", ErrorMessage = "密码两次输入要一致")]
        public string ConfirrmPassWord { get; set; }
    }
}