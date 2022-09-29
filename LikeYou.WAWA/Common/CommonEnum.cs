using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LikeYou.WAWA.Common
{
    public class CommonEnum
    {
      
    }

    public enum UserRole
    {
        超级管理员,
        管理员,
        操作员,
        用户
    }

    public enum MeunType
    {
        菜单,
        按钮
    }

    public enum LogType
    {
        Error,
        Info,
        Debug,
        Warning,
        UserDao,

    }
}
