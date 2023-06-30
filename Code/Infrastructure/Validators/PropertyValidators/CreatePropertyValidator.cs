using Core.DTO.Property;
using FluentValidation;
using Infrastructure.Validators.OwnerValidator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Infrastructure.Validators.PropertyValidators
{
    public class CreatePropertyValidator : AbstractValidator<CreatePropertyDTO>
    {
        public CreatePropertyValidator()
        {
            RuleFor(u => u.Name).Cascade(CascadeMode.Stop)
                                .NotNull().WithMessage("Nombre requerido")
                                .NotEmpty().WithMessage("Nombre requerido")
                                .Length(1, 100).WithMessage("El nombre tiene {TotalLength} y como maximo puede contener {MaxLength} caracteres");
            RuleFor(u => u.Address).Cascade(CascadeMode.Stop)
                                .NotNull().WithMessage("Dirección requerida")
                                .NotEmpty().WithMessage("Dirección requerida")
                                .Length(1, 200).WithMessage("La direccion tiene {TotalLength} y como maximo puede contener {MaxLength} caracteres");
            RuleFor(u => u.Price).Cascade(CascadeMode.Stop)
                                .NotEmpty().WithMessage("Precio requerido")
                                .GreaterThan(0).WithMessage("El precio debe ser mayor a 0")
                                .PrecisionScale(18, 2, true);
            RuleFor(u => u.CodeInternal).Cascade(CascadeMode.Stop)
                                .NotNull().WithMessage("Codigo interno requerido")
                                .NotEmpty().WithMessage("Codigo interno requerido")
                                .Length(1, 50).WithMessage("El codigo interno tiene {TotalLength} y como maximo puede contener {MaxLength} caracteres");
            RuleFor(u => u.Year).Cascade(CascadeMode.Stop)
                                .NotEmpty().WithMessage("año requerido")
                                .GreaterThan(1500).WithMessage("El año debe ser mayor a 1500");
            RuleFor(u => u.Owner).Cascade(CascadeMode.Stop)
                .SetValidator(new CreateOwnerValidator());

        }
    }
}
