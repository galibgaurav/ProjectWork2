using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FluentValidation;
using ProjectWork.Web.Models;

namespace ProjectWork.Web.Infrastructure.Validators
{
    public class ScheduleViewModelValidators : AbstractValidator<ScheduleViewModel>
    {
        public ScheduleViewModelValidators()
        {
            //RuleFor(contact => contact.Name).NotEmpty().NotNull().Length(1, 50).WithMessage("Name must be between 1 - 50 characters");
            RuleFor(schedule => schedule.ScheduleTime).NotEmpty().NotNull();
            RuleFor(schedule => schedule.ContactInfoIDs).NotEmpty().NotNull();
            RuleFor(schedule => schedule.UserID).NotEmpty().NotNull();


        }
    }
}