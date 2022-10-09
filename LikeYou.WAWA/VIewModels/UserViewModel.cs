using CommunityToolkit.Mvvm.DependencyInjection;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using HandyControl.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using LikeYou.WAWA.Common.ICommon;
using LikeYou.WAWA.Common;
using HandyControl.Tools.Extension;
using Microsoft.Extensions.DependencyInjection;
using System.Windows.Input;
using HanumanInstitute.MvvmDialogs;
using HandyControl.Controls;
using SqlSugar;
using CommunityToolkit.Mvvm.ComponentModel;

namespace LikeYou.WAWA.VIewModels
{
    public partial class UserViewModel:BaseViewModel
    {

        #region 搜索字段
        [ObservableProperty]
        public string? s_Name;
        [ObservableProperty]
        public string? s_Eimal;
        [ObservableProperty]
        public string? s_Dept;
        [ObservableProperty]
        public Common.UserRole? s_Role;

        #endregion
   

        [ObservableProperty]
        public List<Models.Personinfo> personinfos;

        public ILogger Logs { get; }

    
        public UserViewModel(IDialogService _dialogService)
        {
             GetPersoninfos();
            SumPageCount();
            dialogService=_dialogService;
        }

        public async void GetPersoninfos()
        {
            Personinfos = await Bll.DBCommon.PeronDao.GetPageListWhere(s => s.IsDelete!=1, PageIndex, PageSize, Total,
                string.IsNullOrEmpty(S_Name)?null: s=>s.Name.Contains(S_Name),
               string.IsNullOrEmpty(S_Dept) ? null : s => s.DeptName.Contains(S_Dept),
                string.IsNullOrEmpty(S_Eimal) ? null : s => s.Eamil.Contains(S_Eimal),
                (S_Role is null || S_Role==Common.UserRole.无 )? null : s => s.UserRole==S_Role
                );
            Total=Total;
        }

        public override void Add()
        {
            ShowDialogAsync(viewModel => dialogService.ShowDialogAsync(this, viewModel));
      
        }

        public override void PageUpdated(FunctionEventArgs<int> info)
        {
            PageIndex= info.Info;
            GetPersoninfos();
        }

        public override void Search()
        {
            GetPersoninfos();
        }

        public override void Export()
        {
            base.Export();
        }

        public override async void Update()
        {
            Models.Personinfo personinfo = Personinfos?.Find(s => s.IsSelect==true);
            if(personinfo is null)
            {
                Growl.Warning("请选择人员！");
                return;
            }
            ShowDialogAsync(viewModel => dialogService.ShowDialogAsync(this, viewModel), personinfo);
        }

        public override void Select(int id)
        {
            var se= Personinfos?.Find(s => s.Id==id);
            if(se !=null)
            {
                se.IsSelect=!se.IsSelect;
            }        
        }

        public override async void Delete()
        {
            if (CheckAll)
            {
                //Personinfos=null;
                foreach(Models.Personinfo personinfo in Personinfos)
                {
                    personinfo.IsDelete=1;
                    if (await Bll.DBCommon.PeronDao.UpdateColumns(personinfo))
                    {
                        Ioc.Default.GetService<Common.ICommon.ILogger>().WriteToFileAndDB($"删除{personinfo.Name}成功", "用户操作");
                        Growl.Success("删除成功！");        
                    }
                    else
                    {
                        Growl.Error("删除失败！");
                    }
                }
              
            }
            else
            {
                Models.Personinfo personinfo = Personinfos?.Find(s => s.IsSelect==true);
                if (personinfo is null)
                {
                    Growl.Warning("请选择人员！");
                    return;
                }
                personinfo.IsDelete=1;
                if (await Bll.DBCommon.PeronDao.UpdateColumns(personinfo))
                {
                    Ioc.Default.GetService<Common.ICommon.ILogger>().WriteToFileAndDB($"删除{personinfo.Name}成功", "用户操作");
                    Growl.Success("删除成功！");
                }
                else
                {
                    Growl.Error("删除失败！");
                }
              
            }
             GetPersoninfos();
        }

        private async Task ShowDialogAsync(Func<EditAddWindowViewModel, Task<bool?>> showDialog,Models.Personinfo personinfo=null)
        {
            var dialogViewModel = dialogService.CreateViewModel<EditAddWindowViewModel>();
            if (personinfo!=null)
            {
                dialogViewModel.Personinfo = personinfo;
                dialogViewModel.IsUpdate=true;
            }
            bool success =(bool) await showDialog(dialogViewModel);
            if (success)
            {
                Search();
            }
        }

      public override void  CheckAllAction()
        {
            Personinfos?.ForEach(s=>s.IsSelect=true);
        }
    }
}
