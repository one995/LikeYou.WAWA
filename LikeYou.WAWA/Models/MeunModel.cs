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
    public class MeunModel
    {
        [SugarColumn(IsIdentity = true, IsPrimaryKey = true)]
        public int Id { get; set; }

        public string UUID { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }

        public string Perent { get; set; }

        public MeunType type { get; set; }

        public string Flag { get; set; }

        [SqlSugar.SugarColumn(IsIgnore =true)]
        public bool IsSelect { get; set; }
        public int IsDelete { get;  set; }
        [SugarColumn(Length = 600)]
        public string? Description { get;  set; }
    }
}
