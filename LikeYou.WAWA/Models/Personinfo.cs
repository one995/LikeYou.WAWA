using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LikeYou.WAWA.Models
{
    public class Personinfo
    {
        public int Id { get; set; }

        public string Name { get; set; }    

        public int Age { get; set; }

        public string ?DeptName { get; set; }

        public string PersonID { set; get; }

        public string Eamil { get; set; }

        public Common.UserRole UserRole { get; set; }

        public DateTime? Created { get; set; }

        public string? CreateUser { get; set; }

        public DateTime? UpdateTime { get; set; }

        public string? UpdateUser { get; set; }
    }
}
