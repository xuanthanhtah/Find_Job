using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace FindJobSolution.ViewModels.System.UsersJobSeeker
{
    public class RegisterRequest
    {
        [Display(Name = "Email")]
        public string Email { get; set; }
        [Display(Name = "Tên đăng nhập")]
        public string UserName { get; set; }
        [Display(Name = "mật khẩu")]
        public string Password { get; set; }
        [Display(Name = "xác thực mật khẩu")]
        public string ConfirmPassword { get; set; }
        
    }
}
