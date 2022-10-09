using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.DependencyInjection;
using DryIoc.ImTools;
using HandyControl.Controls;
using HanumanInstitute.MvvmDialogs;
using LikeYou.WAWA.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LikeYou.WAWA.VIewModels
{
    public partial class EditRoleWindowViewModel : BaseViewModel, IModalDialogViewModel, ICloseable
    {
        //public bool? DialogResult { get; set; }

        public event EventHandler? RequestClose;
        [ObservableProperty]
        private bool isUpdate;
        [ObservableProperty]
        private string title;

        [ObservableProperty]
        private Models.RoleTypes? personinfo;

        [ObservableProperty]
        private bool? dialogResult;

        public EditRoleWindowViewModel()
        {
            if (personinfo is null)
            {
                personinfo=new Models.RoleTypes()
                {
                    RoleUUID=Common.CommonHelper.GuidTo16String(),
                    Status=RoleStatusType.正常,
                    Type=UserRole.用户,
                    IsDelete=0
                };
            }
        }

        public override async void Add()
        {
            if (string.IsNullOrEmpty(personinfo?.Name))
            {
                Growl.Warning("角色名不能为空！");
                return;
            }
            if (string.IsNullOrEmpty(personinfo?.Description))
            {
                Growl.Warning("详情不能为空！");
                return;
            }
            if (!IsUpdate&&await Bll.DBCommon.RoleDao.Count(s => s.Name==personinfo.Name&&s.IsDelete==0)>0)
            {
                Growl.Warning("角色名已存在！");
                return;
            }
            if (!IsUpdate&&await Bll.DBCommon.RoleDao.Count(s => s.RoleUUID==personinfo.RoleUUID&&s.IsDelete==0)>0)
            {
                Growl.Warning("角色名已存在！");
                return;
            }
            bool su = false;
            if (!IsUpdate&&await Bll.DBCommon.RoleDao.AddT(personinfo)>0)
            {
                su=true;
            }
            else
            {
                if (await Bll.DBCommon.RoleDao.Update(personinfo))
                {
                    su=true;

                }

            }
            if (su)
            {
                DialogResult=true;
                RequestClose?.Invoke(this, EventArgs.Empty);
                string msg = IsUpdate ? "更新" : "新增";
                string tip = $"{msg}角色:{personinfo.Name}";
                Ioc.Default.GetService<Common.ICommon.ILogger>().WriteToFileAndDB(tip, "用户操作");
                Growl.Success(tip);
            }


        }


        public override void Canel()
        {
            DialogResult = false;
            RequestClose?.Invoke(this, EventArgs.Empty);

        }
    }
}
