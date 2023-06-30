using Core.DTO.Owner;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Validators.OwnerValidator
{
    public class CreateOwnerValidator : AbstractValidator<CreateOwnerDTO>
    {
        public CreateOwnerValidator()
        {
            RuleFor(u => u.IdOwner).Cascade(CascadeMode.Stop)
                                .NotNull().When(x => string.IsNullOrEmpty(x.Name)).WithMessage("Id requerido")
                                .NotEmpty().When(x => string.IsNullOrEmpty(x.Name)).WithMessage("Id requerido");

            RuleFor(u => u.Name).Cascade(CascadeMode.Stop)
                                .NotNull().When(x => x.IdOwner == 0).WithMessage("Nombre requerido")
                                .NotEmpty().When(x => x.IdOwner == 0).WithMessage("Nombre requerido")
                                .Length(1, 100).WithMessage("La Nombre  tiene {TotalLength} y como maximo puede contener {MaxLength} caracteres");
            RuleFor(u => u.Address).Cascade(CascadeMode.Stop)
                                .NotNull().When(x => x.IdOwner == 0).WithMessage("Dirección requerido")
                                .NotEmpty().When(x => x.IdOwner == 0).WithMessage("Dirección requerido")
                                .Length(1, 100).WithMessage("La dirección tiene {TotalLength} y como maximo puede contener {MaxLength} caracteres");
            RuleFor(u => u.Birthday).Cascade(CascadeMode.Stop)
                                .NotNull().When(x => x.IdOwner == 0).WithMessage("Fecha de nacimiento requerida")
                                .NotEmpty().When(x => x.IdOwner == 0).WithMessage("Fecha de nacimiento requerida")
                                .LessThan(DateTime.Now);
            RuleFor(u => u.PhotoFile).Cascade(CascadeMode.Stop)
                                .NotNull().When(x => x.IdOwner == 0).WithMessage("Foto requerida")
                                .NotEmpty().When(x => x.IdOwner == 0).WithMessage("Foto Requerida")
                                .SetValidator(new FileValidator());
        }
    }
}
