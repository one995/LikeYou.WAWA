using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace LikeYou.WAWA.Models
{
    public class Deptment
    {
        [SugarColumn(IsIdentity = true, IsPrimaryKey = true)]
        public int Id { get; set; }

        public string UUID { get; set; }
        public string Name { get; set; }
        [SugarColumn(IsNullable =true)]
        public string Description { get; set; }
        [SugarColumn(IsNullable = true)]
        public string Perent { get; set; }
        [SugarColumn(IsNullable = true)]
        public string EearchText { get; set; }
    }
}
