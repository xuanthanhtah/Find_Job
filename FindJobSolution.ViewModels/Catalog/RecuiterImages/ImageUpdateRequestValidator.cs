using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindJobSolution.ViewModels.Catalog.RecuiterImages
{
    public class ImageUpdateRequestValidator : AbstractValidator<ImageUpdateRequest>
    {
        public ImageUpdateRequestValidator()
        {
            RuleFor(x => x.Caption).NotEmpty().WithMessage("Caption is required");
            RuleFor(x => x.FileImage).NotEmpty().WithMessage("FileImage is required");
            RuleFor(x => x.SortOrder).NotEmpty().WithMessage("SortOrder is required");
            RuleFor(x => x.IsDefault).NotEmpty().WithMessage("this field is required");
            RuleFor(x => x.CvId).NotEmpty().WithMessage("CvId is required");
        }
    }
}
