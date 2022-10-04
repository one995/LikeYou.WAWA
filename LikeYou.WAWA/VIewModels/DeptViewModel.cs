using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LikeYou.WAWA.VIewModels
{
    public class DeptViewModel:BaseViewModel
    {
        public List<Models.Deptment> _deptments = new List<Models.Deptment>();

        public List<Models.Deptment> Deptments { get =>_deptments; set=>SetProperty(ref _deptments,value); }

        public DeptViewModel()
        {
            _deptments = new List<Models.Deptment>()
            {
                new Models.Deptment()
                {
                    Name="空空如也"
                }
            };
            SumPageCount();
        }

        public override void Search()
        {
            Console.WriteLine(11);
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
