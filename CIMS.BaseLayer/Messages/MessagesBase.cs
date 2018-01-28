using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CIMS.BaseLayer.Messages
{
    public class MessagesBase
    {
        public int MessageID { get; set; }
        public string MessageText { get; set; }
        public string Description { get; set; }
        public string DateSent { get; set; }
        public string UserID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string SentToSelf { get; set; }
        public string Draft { get; set; }
        public string SenderID { get; set; }
    }

    public class MessageGroups
    {
        public int U_ID { get; set; }
        public int ID { get; set; }
        public string UserID { get; set; }
        public string GroupName { get; set; }
        public string OldGroupName { get; set; }
    }
}
