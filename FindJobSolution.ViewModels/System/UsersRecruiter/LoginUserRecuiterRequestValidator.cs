using FluentValidation;

namespace FindJobSolution.ViewModels.System.UsersRecruiter
{
    public class LoginUserRecuiterRequestValidator : AbstractValidator<LoginRecruiterRequest>
    {
        public LoginUserRecuiterRequestValidator()
        {
            RuleFor(x => x.UserName).NotEmpty().WithMessage("Username is required");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Password is required");
        }
    }
}