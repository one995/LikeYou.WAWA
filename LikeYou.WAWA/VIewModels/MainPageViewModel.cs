using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LikeYou.WAWA.Models;
using LikeYou.WAWA.VIewModels;
namespace LikeYou.WAWA.VIewModels
{
    public partial class MainPageViewModel:TBaseViewModel<CardModel>
    {
        public MainPageViewModel()
        {
            DataList = new List<CardModel>()
            {
                new CardModel() { Header = "今日信息",Content="/Image/logol.png",Footer="不知道啊"}
            };
        }
    }
}
