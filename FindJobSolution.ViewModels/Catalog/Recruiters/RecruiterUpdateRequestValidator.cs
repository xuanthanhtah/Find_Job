using FluentValidation;

namespace FindJobSolution.ViewModels.Catalog.Recruiters
{
    public class RecruiterUpdateRequestValidator : AbstractValidator<RecruiterUpdateRequest>
    {
        public RecruiterUpdateRequestValidator()
        {
            RuleFor(x => x.RecruiterId).NotEmpty().WithMessage("RecuiterId is required");
            RuleFor(x => x.Address).NotEmpty().WithMessage("Address is required");
            RuleFor(x => x.ThumbnailRecuiter).NotEmpty().WithMessage("ThumbnailRecuiter is required");
            RuleFor(x => x.CompanyIntroduction).NotEmpty().WithMessage("CompanyIntroduction is required");
            RuleFor(x => x.nameImage).NotEmpty().WithMessage("nameImage is required");
            RuleFor(x => x.CompanyName).NotEmpty().WithMessage("CompanyName is required");
        }
    }
}