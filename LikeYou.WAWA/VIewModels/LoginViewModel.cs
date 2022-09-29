using CommunityToolkit.Mvvm.DependencyInjection;
using CommunityToolkit.Mvvm.Input;
using LikeYou.WAWA.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace LikeYou.WAWA.VIewModels
{
    public class LoginViewModel : BaseViewModel
    {
        public ICommand LoginCommand { get; set; }
        public LoginViewModel()
        {
            LoginCommand = new AsyncRelayCommand(Login);
        }

        public string? loginName;
        public string? loginPassword;
        public string? LoginName { get => loginName; set => SetProperty(ref loginName, value); }

        public string? Password { get => loginPassword; set => SetProperty(ref loginPassword, value); }
        public async Task<bool> Login()
        {

            Console.WriteLine(LoginName);
            Console.WriteLine(Password);
            if (loginName=="123456"&&Password=="123456")
            {
                //初始化数据库


                
                await Task.Delay(100);
                new MainWindow().Show();
                


            }
            return true;
        }

    
    }
}
