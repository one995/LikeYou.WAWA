using CommunityToolkit.Mvvm.Input;
using HandyControl.Data;
using LikeYou.WAWA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LikeYou.WAWA.VIewModels
{
    public class RoleViewModel : BaseViewModel
    {
        public List<Models.RoleTypes> _datalist = new List<Models.RoleTypes>();

        public RoleViewModel(){
            _datalist = new List<Models.RoleTypes>()
            {
                new Models.RoleTypes()
                {
                    Name="空空如也"
                }
            };
            PageCount=(DataList.Count+10-1)/10;
        }

        public List<Models.RoleTypes> DataList
        {
            get =>_datalist;
            set => SetProperty(ref _datalist,value);
        }

        public override void Add()
        {
            base.Add();
        }

        public override void Delete()
        {
            base.Delete();
        }

        public override void Update()
        {
            base.Update();
        }
        #region 操作指令



        #endregion
    }
}
