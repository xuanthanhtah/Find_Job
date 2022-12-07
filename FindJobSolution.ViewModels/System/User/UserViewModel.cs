using System.ComponentModel.DataAnnotations;

namespace FindJobSolution.ViewModels.System.User
{
    public class UserViewModel
    {
        public Guid Id { get; set; }

        [Display(Name = "Tên đăng nhập")]
        public string UserName { get; set; }

        [Display(Name = "Email")]
        public string Email { get; set; }

        public IList<string> Roles { get; set; }
    }
}