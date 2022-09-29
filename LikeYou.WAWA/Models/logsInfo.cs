using LikeYou.WAWA.Common;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace LikeYou.WAWA.Models
{
    public class LogsInfo
    {
   
            [SugarColumn(IsIdentity = true, IsPrimaryKey = true)]
            public int id { get; set; }
            [SugarColumn(Length = 5000)]
            public string LogsMsg { get; set; }

        public DateTime? CreateTime { get; set; } = Common.CommonHelper.GetDateTimeYYYYMMddHHmmss();

            public string? CreateUser { get; set; }

            public LogType logType { get; set; }
            /// <summary>
            /// 关键字
            /// </summary>
            [SugarColumn(Length = 200)]
            public string FlagMsg { get; set; }
        
    }
}
