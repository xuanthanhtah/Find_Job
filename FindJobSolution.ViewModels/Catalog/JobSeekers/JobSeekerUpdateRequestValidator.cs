using FluentValidation;

namespace FindJobSolution.ViewModels.Catalog.JobSeekers
{
    public class JobSeekerUpdateRequestValidator : AbstractValidator<JobSeekerUpdateRequest>
    {
        public JobSeekerUpdateRequestValidator()
        {
            RuleFor(x => x.Address).NotEmpty().WithMessage("Address is required");
            RuleFor(x => x.ThumbnailCv).NotEmpty().WithMessage("Address is required");
            RuleFor(x => x.JobId).NotEmpty().WithMessage("Address is required");
            RuleFor(x => x.DesiredSalary).NotEmpty().WithMessage("Address is required");
            RuleFor(x => x.Gender).NotEmpty().WithMessage("Address is required");
            RuleFor(x => x.Dob).NotEmpty().WithMessage("Date of birth is required");
            RuleFor(x => x.JobSeekerId).NotEmpty().WithMessage("Address is required");
            RuleFor(x => x.nameCv).NotEmpty().WithMessage("Address is required");
            RuleFor(x => x.National).NotEmpty().WithMessage("Address is required");
            RuleFor(x => x.Name).NotEmpty().WithMessage("Address is required");
        }
    }
}