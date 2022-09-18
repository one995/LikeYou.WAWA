using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LikeYou.WAWA.Common
{
    public class StatisDicModel
    {
        public List<Common.CommonEnum.UserRole> ListUserRole = ((Common.CommonEnum.UserRole[]) Enum.GetValues(typeof(Common.CommonEnum.UserRole))).ToList();
    }
}
