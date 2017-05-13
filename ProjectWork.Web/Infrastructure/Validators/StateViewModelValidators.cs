using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FluentValidation;
using ProjectWork.Web.Models;

namespace ProjectWork.Web.Infrastructure.Validators
{
  
    public class StateViewModelValidators : AbstractValidator<StateViewModel>
    {
        public StateViewModelValidators()
        {
            //RuleFor(contact => contact.Name).NotEmpty().NotNull().Length(1, 50).WithMessage("Name must be between 1 - 50 characters");
            RuleFor(state => state.ContactInfoDetails_ID).NotEmpty().NotNull();
            RuleFor(state => state.StateName).NotEmpty().NotNull();
        }
    }
}