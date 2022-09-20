using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LikeYou.WAWA.Models
{
    public class RoleTypes
    {
        public int ID { get; set; }

        public string RoleUUID { get; set; }
        public string Name { get; set; }

        public string Description { get; set; }

        public string Type { get; set; }

        public int Status { get; set; } 
    }
}
