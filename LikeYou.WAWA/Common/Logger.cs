using LikeYou.WAWA.Common.ICommon;
using Serilog.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LikeYou.WAWA.Common
{
    public class Logger:ILogger
    {
        public void WriteToFileAndDB(string message,string flag="Info",LogType log=LogType.Info)
        {
           Serilog.Log.Information(message, flag);
            Models.LogsInfo logs = new Models.LogsInfo();
            logs.LogsMsg=message;
            logs.FlagMsg=flag;
            logs.CreateTime=DateTime.Now;
            logs.logType=log;
            logs.CreateUser= Common.CommonHelper.logsInfo.UserName;
            Bll.DBCommon.LogsDao.Add(logs);
        }

        public void WriteToDB(string message, string flag = "Info", LogType log = LogType.Info)
        {
            Models.LogsInfo logs = new Models.LogsInfo();
            logs.LogsMsg=message;
            logs.FlagMsg=flag;
            logs.CreateTime=DateTime.Now;
            logs.logType=log;
            logs.CreateUser= Common.CommonHelper.logsInfo.UserName;
            Bll.DBCommon.LogsDao.Add(logs);
        }
    }
}
