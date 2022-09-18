using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LikeYou.WAWA.Models
{
    public class PageModel
    {
       public  int PageIndex { get; set; } 

        public int PageCount { get; set; }  

        public int TotalCount { get; set; }

        public int CurrentPage { get; set; }
    }
}
