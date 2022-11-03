using FluentValidation;

namespace FindJobSolution.ViewModels.Catalog.JobInformations
{
    public class JobInformationRequestValidator : AbstractValidator<JobInformationCreateRequest>
    {
        public JobInformationRequestValidator()
        {
            RuleFor(x => x.Benefits).NotEmpty().WithMessage("Benefits is required");
            RuleFor(x => x.JobTitle).NotEmpty().WithMessage("Title is required");
            RuleFor(x => x.Description).NotEmpty().WithMessage("Description is required");
            RuleFor(x => x.Salary).NotEmpty().WithMessage("Salary is required");
            RuleFor(x => x.WorkingLocation).NotEmpty().WithMessage("WorkingLocation is required");
            RuleFor(x => x.RecruiterId).NotEmpty().WithMessage("RecruiterId is required");
            RuleFor(x => x.JobId).NotEmpty().WithMessage("JobId is required hehe");
            RuleFor(x => x.Requirements).NotEmpty().WithMessage("Requirements is required hehe");
            RuleFor(x => x.MinSalary).NotEmpty().WithMessage("MinSalary is required hehe");
            RuleFor(x => x.MaxSalary).NotEmpty().WithMessage("MaxSalary is required hehe");
            RuleFor(x => x.JobType).NotEmpty().WithMessage("JobType is required hehe");
            RuleFor(x => x.JobLevel).NotEmpty().WithMessage("JobLevel is required hehe");
            RuleFor(x => x.JobInformationTimeStart).NotEmpty().WithMessage("JobInformationTimeStart is required hehe");
            RuleFor(x => x.JobInformationTimeEnd).NotEmpty().WithMessage("JobInformationTimeEnd is required hehe");
        }
    }
}