using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindJobSolution.ViewModels.Catalog.JobSeekerOldCompany
{
    public class JobSeekerOldCompanyUpdateRequestValidator : AbstractValidator<JobSeekerOldCompanyUpdateRequest>
    {
        public JobSeekerOldCompanyUpdateRequestValidator()
        {
            RuleFor(x => x.JobTitle).NotEmpty().WithMessage("JobTitle is required");
            RuleFor(x => x.WorkExperience).NotEmpty().WithMessage("WorkExperience is required");
            RuleFor(x => x.WorkingTime).NotEmpty().WithMessage("WorkingTime is required");
            RuleFor(x => x.CompanyName).NotEmpty().WithMessage("CompanyName is required");
            RuleFor(x => x.JobSeekerOldCompanyId).NotEmpty().WithMessage("JobSeekerOldCompanyId is required");
        }
    }
}
