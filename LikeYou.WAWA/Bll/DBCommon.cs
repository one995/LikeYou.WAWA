using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LikeYou.WAWA.Bll
{
    public class DBCommon
    {
        public static Dal.BaseDao<Models.Personinfo> PeronDao { get { return new Dal.BaseDao<Models.Personinfo>(); } }


        public static Dal.BaseDao<Models.LogsInfo> LogsDao { get { return new Dal.BaseDao<Models.LogsInfo>(); } }

    }
}
