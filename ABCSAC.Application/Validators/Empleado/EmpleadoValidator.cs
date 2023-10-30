using ABCSAC.Application.Dtos.Empleado.Request;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABCSAC.Application.Validators.Empleado
{
    public class EmpleadoValidator : AbstractValidator<EmpleadoRequestDto>
    {
        public EmpleadoValidator()
        {
            RuleFor(c => c.Nombres)
                .NotNull().WithMessage("El campo Nombre no puede ser nulo.")
                .NotEmpty().WithMessage("El campo Nombre no puede ser vacío");

            RuleFor(c => c.Apellidos)
                .NotNull().WithMessage("El campo Apellidos no puede ser nulo.")
                .NotEmpty().WithMessage("El campo Apellidos no puede ser vacío");

        }
    }
}
