using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindJobSolution.ViewModels.Catalog.JobInformations
{
    public class JobInformationUpdateRequestValidator : AbstractValidator<JobInformationUpdateRequest>
    {
        public JobInformationUpdateRequestValidator()
        {
            RuleFor(x => x.Benefits).NotEmpty().WithMessage("Benefits is required");
            RuleFor(x => x.JobTitle).NotEmpty().WithMessage("Title is required");
            RuleFor(x => x.Description).NotEmpty().WithMessage("Description is required");
            RuleFor(x => x.Salary).NotEmpty().WithMessage("Salary is required");
            RuleFor(x => x.WorkingLocation).NotEmpty().WithMessage("WorkingLocation is required");
            RuleFor(x => x.JobInformationId).NotEmpty().WithMessage("JobInformationId is required");
            RuleFor(x => x.JobId).NotEmpty().WithMessage("JobId is required");
            RuleFor(x => x.Requirements).NotEmpty().WithMessage("Requirements is required");
            RuleFor(x => x.MinSalary).NotEmpty().WithMessage("MinSalary is required ");
            RuleFor(x => x.MaxSalary).NotEmpty().WithMessage("MaxSalary is required ");
            RuleFor(x => x.JobType).NotEmpty().WithMessage("JobType is required ");
            RuleFor(x => x.JobLevel).NotEmpty().WithMessage("JobLevel is required");
            RuleFor(x => x.JobInformationTimeStart).NotEmpty().WithMessage("JobInformationTimeStart is required");
            RuleFor(x => x.JobInformationTimeEnd).NotEmpty().WithMessage("JobInformationTimeEnd is required ");
        }

    }
}
