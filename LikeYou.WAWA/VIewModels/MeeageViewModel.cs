using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LikeYou.WAWA.VIewModels
{
    public class MeeageViewModel :BaseViewModel
    {
        public string _sendmsg;

        public string SendMsg { get => _sendmsg; set =>SetProperty(ref _sendmsg,value); }

        public string _showmsg;

        public string ShowMsg { get => _showmsg; set => SetProperty(ref _showmsg, value); }

        public RelayCommand SendCmd => new(SendMsgFuntion);

        public void SendMsgFuntion()
        {
            Console.WriteLine(SendMsg);
            ShowMsg+=SendMsg;
            ShowMsg+="\n\r";
            SendMsg ="";
        }
        //public RelayCommand SendCmd { get => _sendCmd; set => SetProperty(ref _sendCmd, value); }


    }
}
