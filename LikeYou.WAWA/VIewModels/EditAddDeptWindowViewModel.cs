using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.DependencyInjection;
using DryIoc.ImTools;
using HandyControl.Controls;
using HanumanInstitute.MvvmDialogs;
using LikeYou.WAWA.Common;
using LikeYou.WAWA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace LikeYou.WAWA.VIewModels
{
    public partial class EditAddDeptWindowViewModel : BaseViewModel, IModalDialogViewModel, ICloseable
    {
        //新增编辑 viewmodel

        [ObservableProperty]
        private Models.Deptment? deptment;
        /// <summary>
        /// 0 新增人员 1 新增组织 2、
        /// </summary>
        public EditAddDeptWindowViewModel()
        {
            //addType=_addType;

            if (!isUpdate)
            {
                deptment =new Deptment()
                {
                    UUID=Common.CommonHelper.GuidTo16String()
                };
            }


        }
        /// <summary>
        /// 修改
        /// </summary>
        [ObservableProperty]
        private bool isUpdate;
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

        public override void Add()
        {
            AddDept();
        }


        #region 新增组织

        private async void AddDept()
        {
            if (string.IsNullOrEmpty(deptment?.Name))
            {
                Growl.Warning("组织名不能为空！");
                return;
            }
            if (string.IsNullOrEmpty(deptment?.Description))
            {
                Growl.Warning("详情不能为空！");
                return;
            }
            if (!IsUpdate&&await Bll.DBCommon.DeptDao.Count(s => s.Name==deptment.Name)>0)
            {
                Growl.Warning("组织名已存在！");
                return;
            }
            bool su = false;
            if (!IsUpdate&&await Bll.DBCommon.DeptDao.AddT(deptment)>0)
            {
                su=true;
            }
            else
            {
                if (await Bll.DBCommon.DeptDao.Update(deptment))
                {
                    su=true;

                }
            }
            if (su)
            {
                dialogResult=true;
                RequestClose?.Invoke(this, EventArgs.Empty);
                string msg = IsUpdate ? "更新" : "新增";
                string tip = $"{msg}组织:{deptment.Name}";
                Ioc.Default.GetService<Common.ICommon.ILogger>().WriteToFileAndDB(tip, "用户操作");
                Growl.Success(tip);
            }
        }

        #endregion

        public override void Canel()
        {
            DialogResult = false;
            RequestClose?.Invoke(this, EventArgs.Empty);

        }
    }
}
