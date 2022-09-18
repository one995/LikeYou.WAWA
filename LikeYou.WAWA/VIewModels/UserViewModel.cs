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
            Personinfos=new List<Models.Personinfo>()
            {
                new Models.Personinfo(){
                    Name="阿修罗",
                    Id=1,
                    PersonID="123456",
                    UpdateTime=DateTime.Now,
                      UserRole=Common.CommonEnum.UserRole.用户,
                    Age=10,
                    Eamil="333333@com",
                    DeptName="地狱"
                    
                },
                   new Models.Personinfo(){
                    Name="阿修罗2",
                    Id=2,
                    PersonID="12345633",
                    UpdateTime=DateTime.Now,
                    UserRole=Common.CommonEnum.UserRole.超级管理员,
                    Age=14,
                    Eamil="33333333433@com",
                    DeptName="地狱火"

                },
            };
        }

   

    }
}
