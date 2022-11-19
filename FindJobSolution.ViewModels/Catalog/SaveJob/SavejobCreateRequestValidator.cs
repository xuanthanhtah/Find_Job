using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindJobSolution.ViewModels.Catalog.SaveJob
{
    public class SavejobCreateRequestValidator : AbstractValidator<SaveJobCreateRequest>
    {
        public SavejobCreateRequestValidator()
        {
            RuleFor(x => x.JobInformationId).NotEmpty().WithMessage("JobInformationId is required");
            //RuleFor(x => x.JobSeekerId).NotEmpty().WithMessage("JobSeekerId is required");
            RuleFor(x => x.TimeSave).NotEmpty().WithMessage("TimeSave is required");
        }
    }
}
