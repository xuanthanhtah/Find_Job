using FluentValidation;

namespace FindJobSolution.ViewModels.System.UsersRecruiter
{
    public class RegisterUserRecuiterRequestValidator : AbstractValidator<RegisterRecuiterRequest>
    {
        public RegisterUserRecuiterRequestValidator()
        {
            RuleFor(x => x.Email).NotEmpty().WithMessage("Email is required")
                .Matches(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$")
                .WithMessage("Email format not match"); ;
            RuleFor(x => x.UserName).NotEmpty().WithMessage("Username is required");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Password is required");
            RuleFor(x => x.ConfirmPassword).NotEmpty().WithMessage("Confirm password is required");
            RuleFor(x => x).Custom((request, context) =>
            {
                if (request.Password != request.ConfirmPassword)
                {
                    context.AddFailure("Confirm password is not match");
                }
            });
        }
    }
}