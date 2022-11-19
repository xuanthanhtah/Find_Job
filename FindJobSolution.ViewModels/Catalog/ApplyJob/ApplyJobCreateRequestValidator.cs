using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindJobSolution.ViewModels.Catalog.ApplyJob
{
    public class ApplyJobCreateRequestValidator : AbstractValidator<ApplyJobCreateRequestNew>
    {
        public ApplyJobCreateRequestValidator()
        {
            //RuleFor(x => x.JobInformationId).NotEmpty().WithMessage("JobInformationId is required");
            //RuleFor(x => x.JobSeekerId).NotEmpty().WithMessage("JobSeekerId is required");
            RuleFor(x => x.TimeApply).NotEmpty().WithMessage("TimeApply is required");
            //RuleFor(x => x.Status).NotEmpty().WithMessage("Status is required");
        }
    }
}
