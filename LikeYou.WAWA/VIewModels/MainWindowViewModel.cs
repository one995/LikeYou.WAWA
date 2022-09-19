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
                case "用户":
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
                default:
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
