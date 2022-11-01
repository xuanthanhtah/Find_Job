using FindJobSolution.ViewModels.Catalog.JobSeekerOldCompany;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindJobSolution.ViewModels.Catalog.Jobs
{
    public class JobCreateRequestValidator : AbstractValidator<JobCreateRequest>
    {
        public JobCreateRequestValidator()
        {
            RuleFor(x => x.JobName).NotEmpty().WithMessage("JobName is required");
        }
    }
}
