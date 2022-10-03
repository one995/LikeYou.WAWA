using CommunityToolkit.Mvvm.Messaging.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LikeYou.WAWA.Models
{
    public class MessageInfo : RequestMessage<Models.Personinfo>
    {
        public string Title { get; set; }
        public string Message { get; set; }

        public object Data { get; set; }
        public int Id { get; set; }
        public DateTime Date { get; set; }

    }
}
