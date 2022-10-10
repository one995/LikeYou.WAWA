using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.DependencyInjection;
using HandyControl.Controls;
using HandyControl.Data;
using HanumanInstitute.MvvmDialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Ink;
using System.Xml.Linq;

namespace LikeYou.WAWA.VIewModels
{
    public partial class DeptViewModel:BaseViewModel
    {
        [ObservableProperty]
        public List<Models.Deptment> deptments ;

        //public List<Models.Deptment> Deptments { get =>_deptments; set=>SetProperty(ref _deptments,value); }

        public DeptViewModel(IDialogService _dialogService)
        {
            dialogService=_dialogService;
            GetPersoninfos();
        }

     

        public override void Search()
        {
            GetPersoninfos();
        }

        public override void Add()
        {
            ShowDialogAsync(viewModel => dialogService.ShowDialogAsync(this, viewModel));
        }

        public override void Update()
        {
            Models.Deptment personinfo = Deptments?.Find(s => s.IsSelect==true);
            if (personinfo is null)
            {
                Growl.Warning("请选择组织！");
                return;
            }
            ShowDialogAsync(viewModel => dialogService.ShowDialogAsync(this, viewModel), personinfo);
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
                foreach (Models.Deptment personinfo in Deptments)
                    {
                        if (await Bll.DBCommon.DeptDao.Delete(personinfo))
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
                    Models.Deptment personinfo = Deptments?.Find(s => s.IsSelect==true);
                    if (personinfo is null)
                    {
                        Growl.Warning("请选择人员！");
                        return;
                    }
                if (HandyControl.Controls.MessageBox.Show($"确定{personinfo.Name}删除？", "提示", MessageBoxButton.OKCancel) ==MessageBoxResult.Cancel)
                {
                    return;
                }
                //personinfo.IsDelete=1;
                if (await Bll.DBCommon.DeptDao.Delete(personinfo))
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

        public async void GetPersoninfos()
        {
            Deptments = await Bll.DBCommon.DeptDao.GetPageListWhere(s => s.Id>0, PageIndex, PageSize, Total
                );
            Total=Total;
        }
        public override void PageUpdated(FunctionEventArgs<int> info)
        {
            PageIndex= info.Info;
            GetPersoninfos();
        }

        private async Task ShowDialogAsync(Func<EditAddDeptWindowViewModel, Task<bool?>> showDialog, Models.Deptment personinfo = null)
        {
            var dialogViewModel = dialogService.CreateViewModel<EditAddDeptWindowViewModel>();
            dialogViewModel.Title="新增组织";
            //dialogViewModel.addType=1;
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
    }
}
