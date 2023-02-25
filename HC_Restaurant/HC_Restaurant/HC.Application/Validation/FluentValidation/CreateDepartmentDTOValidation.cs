using FluentValidation;
using Hc.Application.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HC.Application.Validation.FluentValidation
{
    public class CreateDepartmentDTOValidation : AbstractValidator<CreateDepartmentDTO>
    {
        public CreateDepartmentDTOValidation()
        {
            RuleFor(x => x.DepartmentName).NotEmpty().WithMessage("DepartmentName cannot be empty!").MinimumLength(3).WithMessage("Department name must be at least 3 characters!");
        }
    }
}
