using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace FindJobSolution.ViewModels.System.User
{
    public class ResetPasswordVM
    {
        [Display(Name = "Token")]
        public string Token { get; set; }

        [Display(Name = "Email")]
        public string Email { get; set; }

        [Display(Name = "Mật khẩu mới")]
        public string NewPassword { get; set; }

        [Display(Name = "Xác nhận mật khẩu")]
        public string ConfirmNewPassword { get; set; }
    }
}