using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BaseFrame.IdentityServer.Models
{
    public class ApplicationUser : IdentityUser<int>
    {
        /// <summary>
        /// 登录名
        /// </summary>
        public string LoginName { get; set; }
        /// <summary>
        /// 真实姓名
        /// </summary>
        public string RealName { get; set; }
        /// <summary>
        /// 性别
        /// </summary>
        public int sex { get; set; } = 0;
        /// <summary>
        /// 年龄
        /// </summary>
        public int age { get; set; }
        /// <summary>
        /// 出生日期
        /// </summary>
        public DateTime birth { get; set; } = DateTime.Now;
        /// <summary>
        /// 地址
        /// </summary>
        public string addr { get; set; }

        public bool tdIsDelete { get; set; }

        public ICollection<ApplicationUserRole> UserRoles { get; set; }
    }
}
