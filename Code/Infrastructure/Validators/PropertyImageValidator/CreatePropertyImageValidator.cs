using Core.DTO.PropertyImage;
using Core.DTO.PropertyTrace;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Validators.PropertyImageValidator
{
    public class CreatePropertyImageValidator : AbstractValidator<CreatePropertyImageDTO>
    {
        public CreatePropertyImageValidator() 
        {
            RuleFor(u => u.Image).Cascade(CascadeMode.Stop)
                                .SetValidator(new FileValidator());
            RuleFor(u => u.IdProperty).Cascade(CascadeMode.Stop)
                                .NotNull().WithMessage("Codigo de propiedad requerido");

        }
    }
}
