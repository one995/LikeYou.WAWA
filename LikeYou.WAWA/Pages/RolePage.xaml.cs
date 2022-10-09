using CommunityToolkit.Mvvm.DependencyInjection;
using LikeYou.WAWA.VIewModels;
using System;
using System.Collections.Generic;
using System.Linq;
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

namespace LikeYou.WAWA.Pages
{
    /// <summary>
    /// RolePage.xaml 的交互逻辑
    /// </summary>
    public partial class RolePage : Page
    {
        public RolePage()
        {
            InitializeComponent();
            this.DataContext= Ioc.Default.GetRequiredService<RoleViewModel>();
        }
    }
}
