using FluentValidation;
using Hc.Application.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HC.Application.Validation.FluentValidation
{
    public class CreateRoleDTOValidation : AbstractValidator<CreateRoleDTO>
    {
        public CreateRoleDTOValidation()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("RoleName cannot be empty!").MinimumLength(3).WithMessage("min character :3");
            RuleFor(x => x.AppUsers).Empty();
        }
    }
}
