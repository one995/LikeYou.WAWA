using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.DependencyInjection;
using HandyControl.Controls;
using HandyControl.Data;
using HanumanInstitute.MvvmDialogs.Wpf;
using HanumanInstitute.MvvmDialogs;
using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Ink;
using System.Xml.Linq;

namespace LikeYou.WAWA.VIewModels
{
    public partial class LogInfoViewModel:BaseViewModel
    {
        #region 搜索字段
        [ObservableProperty]
        public string? s_Name;
        [ObservableProperty]
        public string? s_Eimal;
        [ObservableProperty]
        public string? s_Dept;
        [ObservableProperty]
        public Common.LogType? s_LogType;

        [ObservableProperty]
        public DateTime? s_Start;

        [ObservableProperty]
        public DateTime? s_End;
        #endregion


        [ObservableProperty]
        public List<Models.LogsInfo> personinfos;
        //public ILogger Logs { get; }


        public LogInfoViewModel(IDialogService _dialogService)
        {
            s_Start=DateTime.Now.Date;
            s_End=DateTime.Now.Date.AddDays(1).AddSeconds(-1);
            GetPersoninfos();
            SumPageCount();
            dialogService=_dialogService;
           
        }

        public async void GetPersoninfos()
        {
            Personinfos = await Bll.DBCommon.LogsDao.GetPageListWhere(s => s.id>1&&s.CreateTime>=S_Start&&s.CreateTime<=S_End  , PageIndex, PageSize, Total,
            string.IsNullOrEmpty(S_Name) ? null : s => s.LogsMsg.Contains(S_Name),
               string.IsNullOrEmpty(S_Dept) ? null : s => s.FlagMsg.Contains(S_Dept),
                (s_LogType is null) ? null : s => s.logType==(s_LogType)

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
            //Models.Personinfo personinfo = Personinfos?.Find(s => s.IsSelect==true);
            //if (personinfo is null)
            //{
            //    Growl.Warning("请选择人员！");
            //    return;
            //}
            //ShowDialogAsync(viewModel => dialogService.ShowDialogAsync(this, viewModel), personinfo);
        }

        public override void Select(int id)
        {
            //var se = Personinfos?.Find(s => s.id==id);
            //if (se !=null)
            //{
            //    se.IsSelect=!se.IsSelect;
            //}
        }

        public override async void Delete()
        {
            //if (CheckAll)
            //{
            //    //Personinfos=null;
            //    foreach (Models.Personinfo personinfo in Personinfos)
            //    {
            //        personinfo.IsDelete=1;
            //        if (await Bll.DBCommon.PeronDao.UpdateColumns(personinfo))
            //        {
            //            Ioc.Default.GetService<Common.ICommon.ILogger>().WriteToFileAndDB($"删除{personinfo.Name}成功", "用户操作");
            //            Growl.Success("删除成功！");
            //        }
            //        else
            //        {
            //            Growl.Error("删除失败！");
            //        }
            //    }

            //}
            //else
            //{
            //    Models.Personinfo personinfo = Personinfos?.Find(s => s.IsSelect==true);
            //    if (personinfo is null)
            //    {
            //        Growl.Warning("请选择人员！");
            //        return;
            //    }
            //    personinfo.IsDelete=1;
            //    if (await Bll.DBCommon.PeronDao.UpdateColumns(personinfo))
            //    {
            //        Ioc.Default.GetService<Common.ICommon.ILogger>().WriteToFileAndDB($"删除{personinfo.Name}成功", "用户操作");
            //        Growl.Success("删除成功！");
            //    }
            //    else
            //    {
            //        Growl.Error("删除失败！");
            //    }

            //}
            //GetPersoninfos();
        }

        private async Task ShowDialogAsync(Func<EditAddWindowViewModel, Task<bool?>> showDialog, Models.Personinfo personinfo = null)
        {
            var dialogViewModel = dialogService.CreateViewModel<EditAddWindowViewModel>();
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

        public override void CheckAllAction()
        {
            //Personinfos?.ForEach(s => s.IsSelect=true);
        }
    }
}
