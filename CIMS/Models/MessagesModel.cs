using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CIMS.Models
{
    public class MessagesModel
    {
        public int MessageID { get; set; }

        [AllowHtml]
        public string MessageText { get; set; }

        [Required(ErrorMessage = "Description is required")]
        public string Description { get; set; }
        public string DateSent { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string SentToSelf { get; set; }
        public string Draft { get; set; }
        public string SenderID { get; set; }
        public string UserID { get; set; }

        public List<MessagesModel> MessagesList = new List<MessagesModel>();

        public List<MessageGroupsModel> msgGroupList = new List<MessageGroupsModel>();

    }

    public class MessageGroupsModel
    {
        public int U_ID { get; set; }
        public int ID { get; set; }
        public string UserID { get; set; }
        public string GroupName { get; set; }
        public string UserName { get; set; }

        public List<MessageGroupsModel> MessageGroupsList = new List<MessageGroupsModel>();
        public List<UserModel> userList = new List<UserModel>();

        public List<SelectListItem> groupList { get; set; }
    }
}