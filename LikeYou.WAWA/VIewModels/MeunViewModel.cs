using LikeYou.WAWA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LikeYou.WAWA.VIewModels
{
    public class MeunViewModel:BaseViewModel
    {
        public List<Models.MeunModel> _models = new List<Models.MeunModel>();
        public List<Models.MeunModel> Models { get => _models;set=>SetProperty(ref _models,value); }
        public MeunViewModel()
        {
            this._models=_models=new List<MeunModel>()
            {
                new Models.MeunModel()
                {
                    Name ="空空如也"
                }
            };
            SumPageCount(Models.Count);
        }

        public override void Add()
        {
            base.Add();
        }

        public override void Update()
        {
            base.Update();
        }

        public override void Delete()
        {
            base.Delete();
        }
    }
}
