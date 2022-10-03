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

namespace LikeYou.WAWA.VIewModels
{
    public partial class UserViewModel:BaseViewModel
    {
        private readonly RelayCommand addCommand;
        public ICommand AddCommand => addCommand;
        [RelayCommand]
        public void Show()
        {
            Console.WriteLine(111);
            //Windows.EditAddWindow editAdd = new Windows.EditAddWindow();
            //editAdd.Show();
            //Ioc.Default.GetService<ILogger>().Info("Hello world!");
            Serilog.Log.Information("打开窗口");
            var vm = new EditAddWindowViewModel();
            dialogService.ShowDialog(this,vm);

        }


        public List<Models.Personinfo> Personinfos { set=>SetProperty(ref _Personinfos,value); get =>_Personinfos; }

        public List<Models.Personinfo> _Personinfos;
        public bool _showPopu=false;

        public bool ShowPopu { set => SetProperty(ref _showPopu, value); get => _showPopu; }
        public ILogger Logs { get; }

        private readonly IDialogService dialogService;
        public UserViewModel(IDialogService _dialogService)
        {
            _Personinfos =new List<Models.Personinfo>()
            {
                new Models.Personinfo(){
                    Name="没有数据"
                },
            };
            PageCount=(_Personinfos.Count+10-1)/10;
            dialogService=_dialogService;
            addCommand = new RelayCommand(Add);
        }

        public override void Add()
        {
            Serilog.Log.Information("打开窗口");
            //var vm = dialogService.CreateViewModel<EditAddWindowViewModel>();
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

        public override void Update()
        {
            base.Update();
        }

        public override void Delete()
        {
            base.Delete();
        }

        private async Task ShowDialogAsync(Func<EditAddWindowViewModel, Task<bool?>> showDialog)
        {
            var dialogViewModel = dialogService.CreateViewModel<EditAddWindowViewModel>();
            dialogViewModel.Personinfo=new Models.Personinfo
            {
                Name="111",
                DeptName="222"
            };

            

            dialogViewModel.Title = "ssssss";
            dialogViewModel.Text = "ttttt";
            bool? success = await showDialog(dialogViewModel);
   
        }
    }
}
