using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LikeYou.WAWA.Common.ICommon
{
    public interface ILogger
    {
         void WriteToFileAndDB(string message, string flag = "Info", LogType log = LogType.Info);

         void WriteToDB(string message, string flag = "Info", LogType log = LogType.Info);
    }
}
