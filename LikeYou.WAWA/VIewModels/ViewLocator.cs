using HanumanInstitute.MvvmDialogs.Wpf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LikeYou.WAWA.VIewModels
{
    public class ViewLocator : ViewLocatorBase
    {
        /// <inheritdoc />
        protected override string GetViewName(object viewModel) => viewModel.GetType().FullName!.Replace("VIewModels", "Windows").Replace("ViewModel","");
    }
}
