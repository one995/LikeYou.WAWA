using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.DependencyInjection;
using CommunityToolkit.Mvvm.Input;
using HandyControl.Controls;
using LikeYou.WAWA.Common;
using LikeYou.WAWA.Models;
using LikeYou.WAWA.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace LikeYou.WAWA.VIewModels
{
    public partial class EditAddViewModel:BaseViewModel
    {

        [ObservableProperty]
        public Models.Personinfo ?personinfo;

        public EditAddViewModel()
        {
            personinfo = new Models.Personinfo();
            personinfo.PersonID=CommonHelper.GuidToLongID().ToString();
            personinfo.CreateUser=CommonHelper.logsInfo.UserName;
           
        }

        public override async void  Add()
        {
            if (string.IsNullOrEmpty(personinfo?.Name))
            {
                Growl.Warning("用户名不能为空！");
                return;
            }
            if (string.IsNullOrEmpty(personinfo?.Eamil))
            {
                Growl.Warning("邮箱不能为空！");
                return;
            }
            if ( await Bll.DBCommon.PeronDao.Count(s => s.Name==personinfo.Name)>0)
            {
                Growl.Warning("用户名已存在！");
                return;
            }
            if (await Bll.DBCommon.PeronDao.AddT(personinfo)>0)
            {
                Ioc.Default.GetService<Common.ICommon.ILogger>().WriteToFileAndDB($"添加人员:{personinfo.Name}","添加人员");
            }
        }

        public override void Canel()
        {
            Ioc.Default.GetService<EditAddWindow>().Close();
        }
    }
}
