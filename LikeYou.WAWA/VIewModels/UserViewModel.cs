using CommunityToolkit.Mvvm.Input;
using HandyControl.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace LikeYou.WAWA.VIewModels
{
    public class UserViewModel:BaseViewModel
    {

     
        public List<Models.Personinfo> Personinfos { set=>SetProperty(ref _Personinfos,value); get =>_Personinfos; }

        public List<Models.Personinfo> _Personinfos;

        public UserViewModel()
        {
            _Personinfos =new List<Models.Personinfo>()
            {
                new Models.Personinfo(){
                    Name="没有数据"
                },
            };
            PageCount=(_Personinfos.Count+10-1)/10;
        }
     
    }
}
