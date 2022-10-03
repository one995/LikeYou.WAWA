using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.DependencyInjection;
using CommunityToolkit.Mvvm.Input;
using HandyControl.Controls;
using LikeYou.WAWA.Common;
using LikeYou.WAWA.Models;
using LikeYou.WAWA.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using CommunityToolkit.Mvvm.Messaging;
using CommunityToolkit.Mvvm.Messaging.Messages;
using HanumanInstitute.MvvmDialogs;
using Google.Protobuf.WellKnownTypes;
using System.Windows.Forms;
using LikeYou.WAWA.Bll;
using static System.Net.Mime.MediaTypeNames;


namespace LikeYou.WAWA.VIewModels
{
    public partial class EditAddWindowViewModel : BaseViewModel, IModalDialogViewModel, ICloseable
    {


        [ObservableProperty]
        private Models.Personinfo? personinfo;

        public EditAddWindowViewModel()
        {
        }
        [ObservableProperty]
        private string title;

        private string? text;
        public string? Text
        {
            get => text;
            set => SetProperty(ref text, value);
        }
        //[ObservableProperty]
        private bool? dialogResult;
        public bool? DialogResult
        {
            get => dialogResult;
            private set => SetProperty(ref dialogResult, value);
        }


        public event EventHandler? RequestClose;

        public override async void Add()
        {
            if (string.IsNullOrEmpty(personinfo?.Name))
            {
                Growl.Warning("用户名不能为空！");
                return;
            }
            if (string.IsNullOrEmpty(personinfo?.Eamil))
            {
                Growl.Warning("邮箱不能为空！");
                return;
            }
            if (await Bll.DBCommon.PeronDao.Count(s => s.Name==personinfo.Name)>0)
            {
                Growl.Warning("用户名已存在！");
                return;
            }
            if (await Bll.DBCommon.PeronDao.AddT(personinfo)>0)
            {
                dialogResult=true;
                Ioc.Default.GetService<Common.ICommon.ILogger>().WriteToFileAndDB($"添加人员:{personinfo.Name}", "添加人员");
            }

        }


        public override void Canel()
        {
            DialogResult = false;
            RequestClose?.Invoke(this, EventArgs.Empty);

        }

    }
}
