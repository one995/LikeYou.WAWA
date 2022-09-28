using CommunityToolkit.Mvvm.DependencyInjection;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using HandyControl.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using LikeYou.WAWA.Common.ICommon;
using LikeYou.WAWA.Common;
using HandyControl.Tools.Extension;

namespace LikeYou.WAWA.VIewModels
{
    public partial class UserViewModel:BaseViewModel
    {
        [RelayCommand]
        public void Show()
        {
            Console.WriteLine(111);
            //Windows.EditAddWindow editAdd = new Windows.EditAddWindow();
            //editAdd.Show();
            //Ioc.Default.GetService<ILogger>().Info("Hello world!");
            Serilog.Log.Information("打开窗口");
            Ioc.Default.GetService<Windows.EditAddWindow>().ShowDialog();
        }
        public List<Models.Personinfo> Personinfos { set=>SetProperty(ref _Personinfos,value); get =>_Personinfos; }

        public List<Models.Personinfo> _Personinfos;
        public bool _showPopu=false;

        public bool ShowPopu { set => SetProperty(ref _showPopu, value); get => _showPopu; }
        public ILogger Logs { get; }

        public UserViewModel()
        {
            _Personinfos =new List<Models.Personinfo>()
            {
                new Models.Personinfo(){
                    Name="没有数据"
                },
            };
            PageCount=(_Personinfos.Count+10-1)/10;

        }

        public override void Add()
        {
            ShowPopu=!ShowPopu;
        }

        public override void PageUpdated(FunctionEventArgs<int> info)
        {
            base.PageUpdated(info);
        }

        public override void Search()
        {
            base.Search();
        }

        public override void Export()
        {
            base.Export();
        }

        public override void Update()
        {
            base.Update();
        }

        public override void Delete()
        {
            base.Delete();
        }
    }
}
