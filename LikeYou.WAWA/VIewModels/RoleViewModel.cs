using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.DependencyInjection;
using CommunityToolkit.Mvvm.Input;
using HandyControl.Controls;
using HandyControl.Data;
using HandyControl.Tools.Extension;
using HanumanInstitute.MvvmDialogs;
using HanumanInstitute.MvvmDialogs.Wpf;
using LikeYou.WAWA.Bll;
using LikeYou.WAWA.Models;
using LikeYou.WAWA.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Ink;
using System.Xml.Linq;

namespace LikeYou.WAWA.VIewModels
{
    public partial class RoleViewModel : BaseViewModel
    {
        [ObservableProperty]
        public List<Models.RoleTypes> datalist;
       
        public RoleViewModel(IDialogService _dialogService)
        {
            dialogService=_dialogService;
            GetPersoninfos();
    
        }

        //public List<Models.RoleTypes> DataList
        //{
        //    get =>_datalist;
        //    set => SetProperty(ref _datalist,value);
        //}
        private string _dialogResult;

        public string DialogResult
        {
            get => _dialogResult;
#if NET40
            set => Set(nameof(DialogResult), ref _dialogResult, value);
#else
            set => SetProperty(ref _dialogResult, value);
#endif
        }

        public async void GetPersoninfos()
        {
            Datalist = await Bll.DBCommon.RoleDao.GetPageListWhere(s => s.ID>0&&s.IsDelete==0, PageIndex, PageSize, Total);
            Total=Total;
        }
        public override  void Add()
        {
            //hc的弹框
            //DialogResult = await Dialog.Show<EditAddWindow>()
            //    .Initialize<EditAddWindowViewModel>(vm => vm.Title = DialogResult)
            //    .GetResultAsync<string>();
            ShowDialogAsync(viewModel => dialogService.ShowDialogAsync(this, viewModel));
        }

        public override async void Delete()
        {

            if (CheckAll)
            {
                //Personinfos=null;
                foreach (Models.RoleTypes personinfo in Datalist)
                {
                    personinfo.IsDelete=1;
                    if (await Bll.DBCommon.RoleDao.UpdateColumns(personinfo))
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
                Models.RoleTypes personinfo = Datalist?.Find(s => s.IsSelect==true);
                if (personinfo is null)
                {
                    Growl.Warning("请选择人员！");
                    return;
                }
                if(HandyControl.Controls.MessageBox.Show($"确定{personinfo.Name}删除？", "提示", MessageBoxButton.OKCancel) ==MessageBoxResult.OK)
                {
                    personinfo.IsDelete=1;
                    if (await Bll.DBCommon.RoleDao.UpdateColumns(personinfo))
                    {
                        Ioc.Default.GetService<Common.ICommon.ILogger>().WriteToFileAndDB($"删除{personinfo.Name}成功", "用户操作");
                        Search();
                        Growl.Success("删除成功！");
                    }
                    else
                    {
                        Growl.Error("删除失败！");
                    }
                }
            }
            GetPersoninfos();
        }

        public override void Update()
        {
            Models.RoleTypes personinfo = Datalist?.Find(s => s.IsSelect==true);
            if (personinfo is null)
            {
                Growl.Warning("请选择人员！");
                return;
            }
            ShowDialogAsync(viewModel => dialogService.ShowDialogAsync(this, viewModel), personinfo);
        }
        #region 操作指令

        public override void PageUpdated(FunctionEventArgs<int> info)
        {
            PageIndex= info.Info;
            GetPersoninfos();
        }

        public override void Search()
        {
            GetPersoninfos();
        }
        private async Task ShowDialogAsync(Func<EditRoleWindowViewModel, Task<bool?>> showDialog, Models.RoleTypes personinfo = null)
        {
            var dialogViewModel = dialogService.CreateViewModel<EditRoleWindowViewModel>();
            dialogViewModel.Title="新增角色";
            if (personinfo!=null)
            {
                dialogViewModel.Personinfo = personinfo;
                dialogViewModel.IsUpdate=true;

            }
            bool success = (bool)await showDialog(dialogViewModel);
            if (success)
            {
                Search();
            }
        }
        #endregion
    }
}
