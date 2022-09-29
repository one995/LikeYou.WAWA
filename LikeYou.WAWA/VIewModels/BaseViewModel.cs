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

namespace LikeYou.WAWA.VIewModels
{
  
    public partial class BaseViewModel : ObservableObject
    {
        public RelayCommand<FunctionEventArgs<int>> PageUpdatedCmd => new((s) => PageUpdated(s));
        public  RelayCommand SearchCmd => new( Search); 
        public RelayCommand ExportCmd => new( Export);

        public RelayCommand AddCmd =>  new (Add);

        public RelayCommand CanelCmd => new(Canel);

        public RelayCommand UpdateCmd => new ( Update);

        public RelayCommand DeleteCmd =>  new (Delete);
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
        ///     页码
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
            set => SetProperty(ref _roles, value);
#endif
        }
        #region commamd
        public virtual void PageUpdated(FunctionEventArgs<int> info)
        {
            PageIndex =info.Info;

            //int toal=0;

            //PageCount=toal;


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

      

        public virtual void Add()
        {

        }
        public virtual void Canel()
        {

        }
        

        public virtual void Update()
        {

        }



        public virtual void Delete() { }

        public virtual void SumPageCount(int total)
        {
           PageCount =  (total+10-1)/10;
        }

        #endregion
    }
}
