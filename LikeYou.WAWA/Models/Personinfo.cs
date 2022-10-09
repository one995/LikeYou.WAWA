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
    public class Personinfo
    {
        [SugarColumn(IsIdentity = true, IsPrimaryKey = true)]
        public int Id { get; set; }
    
      
        public string Name { get; set; }    

        public int Age { get; set; }
        [SugarColumn(IsNullable = true)]
        public string ?DeptName { get; set; }

        public string PersonID { set; get; }
        [SugarColumn(IsNullable = true)]
        public string Eamil { get; set; }

        public Common.UserRole UserRole { get; set; }

        public DateTime? Created { get; set; }= CommonHelper.GetDateTimeYYYYMMddHHmmss();
        [SugarColumn(IsNullable = true)]
        public string? CreateUser { get; set; }

        public DateTime? UpdateTime { get; set; } = CommonHelper.GetDateTimeYYYYMMddHHmmss();
        [SugarColumn(IsNullable = true)]
        public string? UpdateUser { get; set; }

        public int IsDelete { get; set; }
        [SugarColumn(IsIgnore = true)]
        public bool IsSelect { get; set; }
    }
}
