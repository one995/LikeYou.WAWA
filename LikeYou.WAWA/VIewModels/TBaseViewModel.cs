using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LikeYou.WAWA.VIewModels
{
    public class TBaseViewModel<T> : BaseViewModel
    {
        /// <summary>
        ///     数据列表
        /// </summary>
        private IList<T> _dataList;

        /// <summary>
        ///     数据列表
        /// </summary>
        public IList<T> DataList
        {
            get => _dataList;
#if NET40
        set => Set(nameof(DataList), ref _dataList, value);
#else
            set => SetProperty(ref _dataList, value);
#endif
        }
    }
}
