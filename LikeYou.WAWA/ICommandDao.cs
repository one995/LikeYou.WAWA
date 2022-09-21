using HandyControl.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LikeYou.WAWA
{
    public interface ICommandDao
    {
        void Add(object obj);

        void Delete(object obj);

        void Update(object obj);

        void PageUpdated(FunctionEventArgs<int> info);
    }
}
