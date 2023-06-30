using Core.DTO.Property;
using Core.DTO.PropertyTrace;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Validators.PropertyTraceValidator
{
    public class CreatePropertyTraceValidator : AbstractValidator<CreatePropertyTraceDTO>
    {
        public CreatePropertyTraceValidator()
        {
            RuleFor(u => u.Name).Cascade(CascadeMode.Stop)
                                .NotNull().WithMessage("Nombre requerido")
                                .NotEmpty().WithMessage("Nombre requerido")
                                .Length(1, 100).WithMessage("El nombre tiene {TotalLength} y como maximo puede contener {MaxLength} caracteres");
            RuleFor(u => u.IdProperty).Cascade(CascadeMode.Stop)
                                .NotNull().WithMessage("Codigo de propiedad requerido");
            RuleFor(u => u.Value).Cascade(CascadeMode.Stop)
                                .NotEmpty().WithMessage("Precio requerido")
                                .GreaterThan(0).WithMessage("El precio debe ser mayor a 0")
                                .PrecisionScale(18, 2, true);
            RuleFor(u => u.Tax).Cascade(CascadeMode.Stop)
                                .NotEmpty().WithMessage("Impúesto requerido")
                                .GreaterThan(0).WithMessage("El precio debe ser mayor a 0")
                                .PrecisionScale(18, 2, true);
            RuleFor(u => u.DateSale).Cascade(CascadeMode.Stop)
                                .NotEmpty().WithMessage("Fecha requerida");
        }
    }
}
