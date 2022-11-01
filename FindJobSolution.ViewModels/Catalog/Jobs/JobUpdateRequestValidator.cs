using FindJobSolution.ViewModels.Catalog.JobSeekerOldCompany;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindJobSolution.ViewModels.Catalog.Jobs
{
    public class JobUpdateRequestValidator : AbstractValidator<JobUpdateRequest>
    {
        public JobUpdateRequestValidator()
        {
            RuleFor(x => x.JobName).NotEmpty().WithMessage("JobName is required");
            RuleFor(x => x.JobId).NotEmpty().WithMessage("JobId is required");
        }

    }
}
