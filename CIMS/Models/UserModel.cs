using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CIMS.Models
{
    public class ManageUserModel
    {
        public UserModel userModel { get; set; }
        public List<UserModel> UserList { get; set; }
    }

    public class UserModel
    {
        public int ID { get; set; }

        [Required]
        public string FirstName { get; set; }
         [Required]
        public string LastName { get; set; }
        public string Initials { get; set; }
        public string RegNumber { get; set; }
        public string UserID { get; set; }
       [DataType(DataType.Password)]
       [Required]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Required]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Required]
        [Compare("NewPassword", ErrorMessage = "The new password and confirmation password do not match.")]
        public string ConfirmNewPassword { get; set; }

        [DataType(DataType.Password)]
        [Required]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
        public int UnitID { get; set; }
        public string Skills { get; set; }
        public bool IsDispatchable { get; set; }
        public string PasswordDate { get; set; }
        public bool UserCanChangePassword { get; set; }

        [Required(ErrorMessage = "The Email address is required")]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "E-mail is not valid")]
        public string EMail { get; set; }
         [Required]
        public string UserName { get; set; }

         public string Roles { get; set; }

         public List<Roles> RolesList { get; set; }

        public string FullName { get; set; }
    }
}