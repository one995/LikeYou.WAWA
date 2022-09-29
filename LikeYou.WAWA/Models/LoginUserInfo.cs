using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LikeYou.WAWA.Models
{
    public class LoginUserInfo
    {
        public string UserName { get; set; }

        public string Password { get; set; }

        public RoleTypes Role { get; set; }

        public string DeptName { get; set; }

        public string Power { get; set; }
    }
}
