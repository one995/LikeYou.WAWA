using CommunityToolkit.Mvvm.Input;
using LikeYou.WAWA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using System.Windows.Input;

namespace LikeYou.WAWA.VIewModels
{
    public class PageViewModel:BaseViewModel
    {
        public Action<int> CurrentPageChangeTAction { set; get; }
        public RelayCommand<string> CurrentPageChange { get; set; }

        
        public PageViewModel()
        {
            CurrentPageChange=new RelayCommand<string>((s)=> CurrentPageChangeT(s));
            PageText="第0/0页 共0页";
            CurrentPage=1;
            PageModel = new PageModel();
        }

        private void CurrentPageChangeT(string Type)
        {
            if (Type=="上一页")
            {
                if (CurrentPage<=0)
                {
                    CurrentPage=1;
                }
                else
                {
                    CurrentPage--;
                }       
            }
            int pagesize = (int)((PageModel?.PageCount+PageModel?.PageCount-1)/PageModel?.PageCount);
            if (Type=="下一页")
            {

                if (CurrentPage>=PageModel?.PageCount)
                {
                    CurrentPage=pagesize;
                }
                else
                {
                    CurrentPage++;
                }
                   
            }
            PageText=$"第{PageModel?.CurrentPage}/{(PageModel?.PageCount+PageModel?.PageCount-1)/PageModel?.PageCount}页 共{PageModel?.PageCount}页";
            //回调页数
            CurrentPageChangeTAction?.Invoke(CurrentPage);
        }

        private string _pageText;

        public string PageText
        {
            set => SetProperty(ref _pageText, value);
            get => _pageText;
        }

        private int _CurrentPage;

        public int CurrentPage
        {
            set => SetProperty(ref _CurrentPage, value);
            get => _CurrentPage;
        }
        private PageModel? _pageModel;

        public PageModel PageModel
        {
            set =>SetProperty( ref _pageModel,value); 
            get =>  _pageModel; 
        }
    }
}
