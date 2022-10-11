using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.DependencyInjection;
using HandyControl.Controls;
using HandyControl.Data;
using HanumanInstitute.MvvmDialogs;
using LikeYou.WAWA.Bll;
using LikeYou.WAWA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Ink;
using System.Windows;
using System.Xml.Linq;
using HanumanInstitute.MvvmDialogs.Wpf;

namespace LikeYou.WAWA.VIewModels
{
    public partial class MeunViewModel:BaseViewModel
    {
        private List<Models.MeunModel> _models = new List<Models.MeunModel>();
        public List<Models.MeunModel> MeunDatas { get => _models;set=>SetProperty(ref _models,value); }

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

        public MeunViewModel(IDialogService _dialogService)
        {
            this._models=_models=new List<MeunModel>()
            {
                new Models.MeunModel()
                {
                    Name ="空空如也"
                }
            };
            GetPersoninfos();
            SumPageCount();
            dialogService=_dialogService;
        }

 

        public async void GetPersoninfos()
        {
            MeunDatas = await Bll.DBCommon.MeunDao.GetPageListWhere(s => s.IsDelete==0, PageIndex, PageSize, Total,
            string.IsNullOrEmpty(S_Name) ? null : s => s.Name.Contains(S_Name)
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
            Models.MeunModel personinfo = MeunDatas?.Find(s => s.IsSelect==true);
            if (personinfo is null)
            {
                Growl.Warning("请选择人员！");
                return;
            }
            ShowDialogAsync(viewModel => dialogService.ShowDialogAsync(this, viewModel), personinfo);
        }

        public override void Select(int id)
        {
            var se = MeunDatas?.Find(s => s.Id==id);
            if (se !=null)
            {
                se.IsSelect=!se.IsSelect;
            }
        }

        public override async void Delete()
        {
            if (CheckAll)
            {
                if (HandyControl.Controls.MessageBox.Show($"确定全部删除？", "提示", MessageBoxButton.OKCancel) ==MessageBoxResult.Cancel)
                {
                    return;
                }
                //Personinfos=null;
                foreach (Models.MeunModel personinfo in MeunDatas)
                {
                    personinfo.IsDelete=1;
                    if (await Bll.DBCommon.MeunDao.UpdateColumns(personinfo))
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
                Models.MeunModel personinfo = MeunDatas?.Find(s => s.IsSelect==true);
                if (personinfo is null)
                {
                    Growl.Warning("请选择人员！");
                    return;
                }
                if (HandyControl.Controls.MessageBox.Show($"确定{personinfo.Name}删除？", "提示", MessageBoxButton.OKCancel) ==MessageBoxResult.Cancel)
                {
                    return;
                }
                personinfo.IsDelete=1;
                if (await Bll.DBCommon.MeunDao.UpdateColumns(personinfo))
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

        private async Task ShowDialogAsync(Func<EditAddMeunWindowViewModel, Task<bool?>> showDialog, Models.MeunModel personinfo = null)
        {
            var dialogViewModel = dialogService.CreateViewModel<EditAddMeunWindowViewModel>();
            dialogViewModel.Title="新增菜单";
            if (personinfo!=null)
            {
                dialogViewModel.Deptment = personinfo;
                dialogViewModel.IsUpdate=true;
            }
            bool success = (bool)await showDialog(dialogViewModel);
            if (success)
            {
                Search();
            }
        }

        public override void CheckAllAction()
        {
            MeunDatas?.ForEach(s => s.IsSelect=true);
        }
    }
}
