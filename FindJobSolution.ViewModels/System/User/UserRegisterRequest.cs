using System.ComponentModel.DataAnnotations;

namespace FindJobSolution.ViewModels.System.User
{
    public class UserRegisterRequest
    {
        [Display(Name = "Địa chỉ mail")]
        [DataType(DataType.EmailAddress)]   
        public string Email { get; set; }

        [Display(Name = "Tên tài khoản")]
        public string UserName { get; set; }

        [Display(Name = "Mật khẩu")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Xác nhận mật khẩu")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
    }
}