using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using CommunityToolkit.Mvvm.Input;
using HandyControl.Controls;
using HandyControl.Data;
using LikeYou.WAWA.Models;
namespace LikeYou.WAWA.MyControl
{
    /// <summary>
    /// PageChangeControl.xaml 的交互逻辑
    /// </summary>
    public partial class PageChangeControl : UserControl
    {
        public PageChangeControl()
        {
            InitializeComponent();
            //CurrentPageChange=new RelayCommand<string>((s) => CurrentPageChangeT(s));
            PageStr.Content = "第0/0页 共0页";
            CurrentPage=1;
            //PageModel = new PageModel();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            CurrentPage--;
        }

        //private void CurrentPageChangeT(string Type)
        //{
        //    if (Type=="上一页")
        //    {
        //        if (CurrentPage<=0)
        //        {
        //            CurrentPage=1;
        //        }
        //        else
        //        {
        //            CurrentPage--;
        //        }
        //    }
        //    int pagesize = (int)((PageModel?.PageCount+PageModel?.PageCount-1)/PageModel?.PageCount);
        //    if (Type=="下一页")
        //    {

        //        if (CurrentPage>=PageModel?.PageCount)
        //        {
        //            CurrentPage=pagesize;
        //        }
        //        else
        //        {
        //            CurrentPage++;
        //        }

        //    }
        //    PageText=$"第{PageModel?.CurrentPage}/{(PageModel?.PageCount+PageModel?.PageCount-1)/PageModel?.PageCount}页 共{PageModel?.PageCount}页";
        //    //回调页数
        //    CurrentPageChangeTAction?.Invoke(CurrentPage);
        //}

        private string PageText { get; set; }

        //public string PageText
        //{
        //    set => SetProperty(ref _pageText, value);
        //    get => _pageText;
        //}

        private int CurrentPage;

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            CurrentPage++;
            PageStr.Content = PageText;
        }

        //private PageModel? _pageModel;

        //public PageModel PageModel
        //{
        //    set => SetProperty(ref _pageModel, value);
        //    get => _pageModel;
        //}

    }
}
