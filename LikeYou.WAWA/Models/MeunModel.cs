using LikeYou.WAWA.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LikeYou.WAWA.Models
{
    public class MeunModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }

        public string Perent { get; set; }

        public MeunType type { get; set; }

        public string Flag { get; set; }
    }
}
