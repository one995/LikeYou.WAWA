using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace LikeYou.WAWA.VIewModels
{
    public partial class EditAddViewModel:BaseViewModel
    {

        [RelayCommand]
        public void Show()
        {
            MessageBox.Show("1111");
        }
    }
}
