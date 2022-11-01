using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindJobSolution.ViewModels.Catalog.Cvs
{
    public class CvUpdateRequestValidator : AbstractValidator<CvUpdateRequest>   
    {
        public CvUpdateRequestValidator()
        {
            RuleFor(x => x.FileCv).NotEmpty().WithMessage("FileCV is required");
            RuleFor(x => x.Caption).NotEmpty().WithMessage("Caption is required");
            RuleFor(x => x.IsDefault).NotEmpty().WithMessage("required");
            RuleFor(x => x.SortOrder).NotEmpty().WithMessage("SortOrder is required");
            RuleFor(x => x.CvId).NotEmpty().WithMessage("CvId is required");
        }
    }
}
