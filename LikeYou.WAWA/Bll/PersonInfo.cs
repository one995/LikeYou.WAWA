using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LikeYou.WAWA.Bll
{
    public class PersonInfo
    {
        private static Dal.BaseDao<Models.Personinfo> baseDao = new Dal.BaseDao<Models.Personinfo>();


        public static async Task< int> Add(Models.Personinfo personinfo)
        {
            return  await baseDao.AddT(personinfo);
        }

        public static async Task<bool> Delete(Models.Personinfo personinfo)
        {
            return await baseDao.Delete(personinfo);
        }

        public static async Task<bool> Update(Models.Personinfo personinfo)
        {
            return await baseDao.Update(personinfo);
        }

    }
}
