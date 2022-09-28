using LikeYou.WAWA.Common;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LikeYou.WAWA.Dal
{
    public class DbDao
    {
        public static SqlSugarScope RWDb = DBHelper._instance.RWscope;
    }
}
