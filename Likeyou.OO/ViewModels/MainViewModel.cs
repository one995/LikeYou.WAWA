using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Likeyou.OO.ViewModels
{

    public partial class MainViewModel
    {
    
        private string? name;
        public string Name { get; set; } = "text";
        public void Msg()
        {
            Console.WriteLine(111);
        }

       
    }
}
