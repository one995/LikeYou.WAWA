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
using System.Windows.Shapes;
using LikeYou.WAWA.VIewModels;
namespace LikeYou.WAWA.Windows
{
    /// <summary>
    /// EditAddWindow.xaml 的交互逻辑
    /// </summary>
    public partial class EditAddWindow : Window
    {
        public EditAddWindow()
        {
            InitializeComponent();
            this.DataContext = new EditAddViewModel();
        }
    }
}
