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

        public RelayCommand<FunctionEventArgs<int>> PageUpdatedCmd => new((s)=>PageUpdated(s));
        public RelayCommand SearchCmd => new(Search);
        public RelayCommand ExportCmd => new(Export);
        public List<Models.Personinfo> Personinfos { set=>SetProperty(ref _Personinfos,value); get =>_Personinfos; }

        public List<Models.Personinfo> _Personinfos;

        public UserViewModel()
        {    
            Personinfos =new List<Models.Personinfo>()
            {
                new Models.Personinfo(){
                    Name="阿修罗",
                    Id=1,
                    PersonID="123456",
                    UpdateTime=DateTime.Now,
                      UserRole=Common.UserRole.用户,
                    Age=10,
                    Eamil="333333@com",
                    DeptName="地狱"
                    
                },
                   new Models.Personinfo(){
                    Name="阿修罗2",
                    Id=2,
                    PersonID="12345633",
                    UpdateTime=DateTime.Now,
                    UserRole=Common.UserRole.超级管理员,
                    Age=14,
                    Eamil="33333333433@com",
                    DeptName="地狱火"

                },
                   new Models.Personinfo(){
                    Name="阿修罗2",
                    Id=2,
                    PersonID="12345633",
                    UpdateTime=DateTime.Now,
                    UserRole=Common.UserRole.超级管理员,
                    Age=14,
                    Eamil="33333333433@com",
                    DeptName="地狱火"

                },
                   new Models.Personinfo(){
                    Name="阿修罗2",
                    Id=2,
                    PersonID="12345633",
                    UpdateTime=DateTime.Now,
                    UserRole=Common.UserRole.超级管理员,
                    Age=14,
                    Eamil="33333333433@com",
                    DeptName="地狱火"


                },
                   new Models.Personinfo(){
                    Name="阿修罗2",
                    Id=2,
                    PersonID="12345633",
                    UpdateTime=DateTime.Now,
                    UserRole=Common.UserRole.超级管理员,
                    Age=14,
                    Eamil="33333333433@com",
                    DeptName="地狱火"

                },
                   new Models.Personinfo(){
                    Name="阿修罗2",
                    Id=2,
                    PersonID="12345633",
                    UpdateTime=DateTime.Now,
                    UserRole=Common.UserRole.超级管理员,
                    Age=14,
                    Eamil="33333333433@com",
                    DeptName="地狱火"

                },
                   new Models.Personinfo(){
                    Name="阿修罗2",
                    Id=2,
                    PersonID="12345633",
                    UpdateTime=DateTime.Now,
                    UserRole=Common.UserRole.超级管理员,
                    Age=14,
                    Eamil="33333333433@com",
                    DeptName="地狱火"

                },
                   new Models.Personinfo(){
                    Name="阿修罗2",
                    Id=2,
                    PersonID="12345633",
                    UpdateTime=DateTime.Now,
                    UserRole=Common.UserRole.超级管理员,
                    Age=14,
                    Eamil="33333333433@com",
                    DeptName="地狱火"

                },
                   new Models.Personinfo(){
                    Name="阿修罗2",
                    Id=2,
                    PersonID="12345633",
                    UpdateTime=DateTime.Now,
                    UserRole=Common.UserRole.超级管理员,
                    Age=14,
                    Eamil="33333333433@com",
                    DeptName="地狱火"

                },
                   new Models.Personinfo(){
                    Name="阿修罗2",
                    Id=2,
                    PersonID="12345633",
                    UpdateTime=DateTime.Now,
                    UserRole=Common.UserRole.超级管理员,
                    Age=14,
                    Eamil="33333333433@com",
                    DeptName="地狱火"

                },
                   new Models.Personinfo(){
                    Name="阿修罗2",
                    Id=2,
                    PersonID="12345633",
                    UpdateTime=DateTime.Now,
                    UserRole=Common.UserRole.超级管理员,
                    Age=14,
                    Eamil="33333333433@com",
                    DeptName="地狱火"

                },
                   new Models.Personinfo(){
                    Name="阿修罗2",
                    Id=2,
                    PersonID="12345633",
                    UpdateTime=DateTime.Now,
                    UserRole=Common.UserRole.超级管理员,
                    Age=14,
                    Eamil="33333333433@com",
                    DeptName="地狱火"

                },
                   new Models.Personinfo(){
                    Name="阿修罗2",
                    Id=2,
                    PersonID="12345633",
                    UpdateTime=DateTime.Now,
                    UserRole=Common.UserRole.超级管理员,
                    Age=14,
                    Eamil="33333333433@com",
                    DeptName="地狱火"

                },
                   new Models.Personinfo(){
                    Name="阿修罗2",
                    Id=2,
                    PersonID="12345633",
                    UpdateTime=DateTime.Now,
                    UserRole=Common.UserRole.超级管理员,
                    Age=14,
                    Eamil="33333333433@com",
                    DeptName="地狱火"

                },
                   new Models.Personinfo(){
                    Name="阿修罗2",
                    Id=2,
                    PersonID="12345633",
                    UpdateTime=DateTime.Now,
                    UserRole=Common.UserRole.超级管理员,
                    Age=14,
                    Eamil="33333333433@com",
                    DeptName="地狱火"

                },
                   new Models.Personinfo(){
                    Name="阿修罗2",
                    Id=2,
                    PersonID="12345633",
                    UpdateTime=DateTime.Now,
                    UserRole=Common.UserRole.超级管理员,
                    Age=14,
                    Eamil="33333333433@com",
                    DeptName="地狱火"

                },
            };
            _pageCount=(Personinfos.Count+10-1)/10;
        }


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
        public void PageUpdated(FunctionEventArgs<int> info)
        {
            PageIndex =info.Info;

            //int toal=0;

            //PageCount=toal;

          
        }
        /// <summary>
        /// 查询方法
        /// </summary>
        public void Search()
        {

        }
        /// <summary>
        /// 导出方法
        /// </summary>
        public void Export()
        {

        }
        #endregion
    }
}
