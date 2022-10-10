using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using HandyControl.Data;
using HanumanInstitute.MvvmDialogs;
using HanumanInstitute.MvvmDialogs.Wpf;

namespace LikeYou.WAWA.VIewModels
{


    public partial class BaseViewModel : ObservableObject
    {
        public  IDialogService dialogService;
        public RelayCommand<FunctionEventArgs<int>> PageUpdatedCmd => new((s) => PageUpdated(s));
        public  RelayCommand SearchCmd => new(Search);

        public RelayCommand<string> ExetenCmd => new((s)=>Exeten(s));


        /// <summary>
        ///     页码
        /// </summary>
        private int _pageIndex = 1;

        /// <summary>
        ///     页码
        /// </summary>
        public int PageIndex
        {
            get => _pageIndex;
#if NET40
            set => Set(nameof(PageIndex), ref _pageIndex, value);
#else
            set => SetProperty(ref _pageIndex, value);
#endif
        }

        /// <summary>
        ///     页面总数
        /// </summary>
        private int _pageCount = 1;

        /// <summary>
        ///     页面总数
        /// </summary>
        public int PageCount
        {
            get => _pageCount;
#if NET40
            set => Set(nameof(PageIndex), ref _pageIndex, value);
#else
            set => SetProperty(ref _pageCount, value);
#endif
        }

        /// <summary>
        ///     页面总数
        /// </summary>
        private SqlSugar.RefAsync<int> _total = 0;

        /// <summary>
        ///     页面总数
        /// </summary>
        public SqlSugar.RefAsync<int> Total
        {
            get => _total;
#if NET40
            set => Set(nameof(PageIndex), ref _pageIndex, value);
#else
            set { SetProperty(ref _total, value); SumPageCount(); }
#endif
        }
        //[ObservableProperty]
        //public SqlSugar.RefAsync<int> total = 0;

        [ObservableProperty]
        public  int  pageSize = 10;

        /// <summary>
        ///     
        /// </summary>
        private Common.UserRole _roles;

        /// <summary>
        ///     页码
        /// </summary>
        public Common.UserRole Roles
        {
            get => _roles;
#if NET40
            set => Set(nameof(PageIndex), ref _pageIndex, value);
#else
            set { SetProperty(ref _roles, value);  }
#endif
        }
        #region commamd
        public virtual void PageUpdated(FunctionEventArgs<int> info)
        {
            PageIndex =info.Info;

            //int toal=0;

            //PageCount=toal;


        }

        public virtual void Exeten(String fNAME)
        {
            switch (fNAME)
            {
                case "新增":
                case "确定":
                    Add();
                    break;
                case "修改":
                    Update();
                    break;
                case "删除":
                    Delete();
                    break;
                case "查询":
                    Search();
                    break;
                case "导出":
                    Export();
                    break;
                case "取消":
                    Canel();
                    break;
                case "分配菜单":
                case "分配组织":
                case "分配权限":
                    Other();
                    break;

            }
        }

        public virtual void Other()
        {

        }


        /// <summary>
        /// 查询方法
        /// </summary>
        public virtual void Search()
        {

        }
        /// <summary>
        /// 导出方法
        /// </summary>
        public virtual void Export()
        {

        }

        public virtual void Select(int id) { }
        public virtual void Add()
        {
            Console.WriteLine(111);
        }
        public virtual void Canel()
        {

        }
        

        public virtual void Update()
        {

        }



        public virtual void Delete() { }

        public virtual void SumPageCount()
        {
           PageCount =  (Total+PageSize-1)/PageSize;
        }

        /// <summary>
        /// 执行全选方法
        /// </summary>
        public bool CheckAll
        {
            get => _checkAll;
            set
            {
                SetProperty(ref _checkAll, value);
                CheckAllAction();
            }
        }

        private bool _checkAll; //全选
        /// <summary>
        /// 子类重写重选方法
        /// </summary>
        public virtual void CheckAllAction() { }


        #endregion
    }
}
