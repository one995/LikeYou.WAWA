using CommunityToolkit.Mvvm.DependencyInjection;
using LikeYou.WAWA.VIewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LikeYou.WAWA
{
    public class ViewModelLocator
    {
        public UserViewModel userViewModel => Ioc.Default.GetRequiredService<UserViewModel>();
    }
}
