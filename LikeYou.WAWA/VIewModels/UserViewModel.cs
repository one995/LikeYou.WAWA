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
        private readonly RelayCommand addCommand;

        [ObservableProperty]
        public List<Models.Personinfo> personinfos;

        //public List<Models.Personinfo> _Personinfos;
        public bool _showPopu=false;

        public bool ShowPopu { set => SetProperty(ref _showPopu, value); get => _showPopu; }
        public ILogger Logs { get; }

        private readonly IDialogService dialogService;
        public UserViewModel(IDialogService _dialogService)
        {
            Personinfos =  GetPersoninfos().Result;
            SumPageCount();
            dialogService=_dialogService;
        }

        public async Task< List<Models.Personinfo>> GetPersoninfos()
        {
            var me = await Bll.DBCommon.PeronDao.GetPageList(s => s.PersonID!=null, PageIndex, PageSize, Total);
            return me;
        }

        public override void Add()
        {
            Serilog.Log.Information("打开窗口");
            ShowDialogAsync(viewModel => dialogService.ShowDialogAsync(this, viewModel));
        }

        public override void PageUpdated(FunctionEventArgs<int> info)
        {
            base.PageUpdated(info);
        }

        public override void Search()
        {
            base.Search();
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
        public bool CheckAll
        {
            get => _checkAll;
            set
            {
                SetProperty(ref _checkAll, value);
                Personinfos?.ForEach(s => s.IsSelect=value);
            }
        }

        private bool _checkAll; //全选


        public override void Delete()
        {
            if (CheckAll)
            {
                Personinfos=null;
                Console.WriteLine("qqq");
            }
        }

        private async Task ShowDialogAsync(Func<EditAddWindowViewModel, Task<bool?>> showDialog,Models.Personinfo personinfo=null)
        {
            var dialogViewModel = dialogService.CreateViewModel<EditAddWindowViewModel>();
            if (personinfo!=null)
            {
                dialogViewModel.Personinfo = personinfo;
                dialogViewModel.IsUpdate=true;
            }
            bool? success = await showDialog(dialogViewModel);
            
        }
    }
}
