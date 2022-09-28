using LikeYou.WAWA.Models;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Shapes;

namespace LikeYou.WAWA.Common
{
    public class DBHelper
    {
        //获取数据库连接字符串和数据库类型 ，数据库对象使用工厂模式
        public static DBHelper _instance { get { return new DBHelper(); } }
        private DbType _dbType;
        static readonly DBConntionArr DB = Appsettings.app<DBConntionArr>(new string[] { "DB" })?.Find(S => S.IsUse==true);

        public SqlSugarScope RWscope { get; set; }

        public DBHelper()
        {
            RWscope = new SqlSugarScope(new ConnectionConfig()
            {
                ConnectionString = DB?.Connstr,//连接符字串
                DbType = DB?.Type == 0 ? DbType.MySql : DbType.SqlServer,//数据库类型
                IsAutoCloseConnection = true //不设成true要手动close
            });
            //每次Sql执行前事件
            RWscope.Aop.OnLogExecuting = (sql, pars) =>
            {
                //我可以在这里面写逻辑
                Serilog.Log.Information(sql, pars);
                Console.WriteLine(sql);
            };
            RWscope.Aop.OnLogExecuted = (sql, p) =>
            {
                if (RWscope.Ado.SqlExecutionTime.TotalSeconds > 1)
                {
                    //代码CS文件名
                    var fileName = RWscope.Ado.SqlStackTrace.FirstFileName;
                    //代码行数
                    var fileLine = RWscope.Ado.SqlStackTrace.FirstLine;
                    //方法名
                    var FirstMethodName = RWscope.Ado.SqlStackTrace.FirstMethodName;
                    //db.Ado.SqlStackTrace.MyStackTraceList[1].xxx 获取上层方法的信息

                    Serilog.Log.Information($"OnLogExecuted:{fileName}-{fileLine}-{FirstMethodName}-usetime:{RWscope.Ado.SqlExecutionTime.ToString()}");
                }
            };
            RWscope.Aop.OnError = (exp) =>//SQL报错
            {
                //exp.sql 这样可以拿到错误SQL
                Serilog.Log.Error(exp.Sql);
            };

            RWscope.Aop.DataExecuting = (oldValue, entityInfo) =>
            {
                //inset生效
                if (entityInfo.PropertyName == "CreateTime" && entityInfo.OperationType == DataFilterType.InsertByObject)
                {
                    entityInfo.SetValue(DateTime.Now);//修改CreateTime字段
                                                      //entityInfo有字段所有参数
                }
                //update生效        
                if (entityInfo.PropertyName == "UpdateTime" && entityInfo.OperationType == DataFilterType.UpdateByObject)
                {
                    entityInfo.SetValue(DateTime.Now);//修改UpdateTime字段
                }
            };

            //RWscope.CodeFirst.SetStringDefaultLength(200).InitTables(typeof(Like.Model.Models.Article));//这样一个表就能成功创建了
        }
    }
}
