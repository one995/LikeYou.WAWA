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
    public class RoleTypes
    {
        [SugarColumn(IsIdentity = true, IsPrimaryKey = true)]
        public int ID { get; set; }

        public string RoleUUID { get; set; }
        public string Name { get; set; }

        public string Description { get; set; }

        public UserRole Type { get; set; }
        /// <summary>
        /// 使用中0, 弃用 1
        /// </summary>
        public RoleStatusType Status { get; set; }

        public int IsDelete { get; set; }
        [SugarColumn(IsIgnore = true)]
        public bool IsSelect { get; set; }
    }
}
