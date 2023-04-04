using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Validations
{
    internal class HeaderValidator : AbstractValidator<Header>
    {
        public HeaderValidator()
        {
            RuleFor(m => m.HeaderName);
        }
    }
}
