using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Navigation;
using CommunityToolkit.Mvvm;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using HandyControl.Controls;
using HandyControl.Data;

namespace LikeYou.WAWA.VIewModels
{

    public partial class MainWindowViewModel:BaseViewModel
    {


  

        public MainWindowViewModel()
        {
            Title="首页";
            Common.CommonHelper.logsInfo = new Models.LoginUserInfo { UserName="admin" };
            LoadsDB();
            this.MainActivePage=new Uri(@"../Pages/MainPage.xaml", UriKind.Relative);
        }
        private void LoadsDB()
        {
            try
            {
                Common.DBHelper._instance.RWscope.CodeFirst.SetStringDefaultLength(200).InitTables(typeof(Models.LogsInfo));//这样一个表就能成功创建了
                Common.DBHelper._instance.RWscope.CodeFirst.SetStringDefaultLength(200).InitTables(typeof(Models.Personinfo));//这样一个表就能成功创建了
                Common.DBHelper._instance.RWscope.CodeFirst.SetStringDefaultLength(200).InitTables(typeof(Models.Deptment));//这样一个表就能成功创建了
                Common.DBHelper._instance.RWscope.CodeFirst.SetStringDefaultLength(200).InitTables(typeof(Models.RoleTypes));//这样一个表就能成功创建了
                Common.DBHelper._instance.RWscope.CodeFirst.SetStringDefaultLength(200).InitTables(typeof(Models.MeunModel));//这样一个表就能成功创建了
            }
            catch (Exception ex)
            {
                Serilog.Log.Error("初始化数据库异常:"+ex);
            }

        }
        public RelayCommand<FunctionEventArgs<object>> SwitchItemCmd => new(SwitchItem);
         
        private void SwitchItem(FunctionEventArgs<object> info) {

            string page = (info.Info as SideMenuItem)?.Header.ToString();
            if (string.IsNullOrEmpty(page))
            {
                Growl.Warning("页面不存在！");
                return;
            }
            _title=page;
            switch (page)
            {
                case "首页":
                    //NavigationService.GetNavigationService(this).Navigate(new Pages.MainPage());//切换到Alice的页面
                    this.MainActivePage=new Uri(@"../Pages/MainPage.xaml", UriKind.Relative) ;
                    break;
                case "管理员账户":
                    this.MainActivePage=new Uri(@"../Pages/UserPage.xaml", UriKind.Relative);
                    break;
                case "角色":      
                    this.MainActivePage=new Uri(@"../Pages/RolePage.xaml", UriKind.Relative);
                    break;
                case "权限管理":
             
                    this.MainActivePage=new Uri(@"../Pages/PowerPage.xaml", UriKind.Relative);
                    break;
                case "组织管理":
              
                    this.MainActivePage=new Uri(@"../Pages/DeptPage.xaml", UriKind.Relative);
                    break;
                case "菜单管理":

                    this.MainActivePage=new Uri(@"../Pages/MeunPage.xaml", UriKind.Relative);
                    break;
                case "聊天室":
               
                    this.MainActivePage=new Uri(@"../Pages/MessagePage.xaml", UriKind.Relative);
                    break;
                case "关于":
             
                    this.MainActivePage=new Uri(@"../Pages/AboutPage.xaml", UriKind.Relative);
                    break;
                case "系统管理":
                    this.MainActivePage=new Uri(@"../Pages/AboutPage.xaml", UriKind.Relative);
                    break;
                case "系统设置":
                    this.MainActivePage=new Uri(@"../Pages/SystemInfo.xaml", UriKind.Relative);
                    break;
                case "系统日志":
                    this.MainActivePage=new Uri(@"../Pages/LogInfo.xaml", UriKind.Relative);
                    break;
                default:
                    this.MainActivePage=new Uri(@"../Pages/MainPage.xaml", UriKind.Relative);
                    break;
            }
           
        }

        //public RelayCommand<string> SelectCmd => new(Select);

        //private void Select(string header) => Growl.Success(header);

        

        public string? _TextBlockFabricIcons;
        public string? TextBlockFabricIcons { get => _TextBlockFabricIcons; set => SetProperty(ref _TextBlockFabricIcons, value); }

        public string? _title;
        public string? Title { get => _title; set => SetProperty(ref _title, value); }

        public Uri? _MainActivePage;
        public Uri? MainActivePage { get => _MainActivePage; set => SetProperty(ref _MainActivePage, value); }
    }
}
