using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FluentValidation;
using ProjectWork.Web.Models;

namespace ProjectWork.Web.Infrastructure.Validators
{
    public class ContactInfoModelValidators: AbstractValidator<ContactData>
    {
        public ContactInfoModelValidators()
        {
            RuleFor(contact => contact.name).NotEmpty().NotNull().Length(1,50).WithMessage("Name must be between 1 - 50 characters") ;
            RuleFor(contact => contact.addressCorrespondance).NotNull().Length(10, 100).WithMessage("Correspondence address must be between 1 - 100 characters");
            RuleFor(contact => contact.addressPermanent).NotNull().Length(10, 100).WithMessage("Permanent address must be between 1 - 100 characters");
            RuleFor(contact => contact.primaryContactNumber).NotNull();
            RuleFor(contact => contact.primaryEmail);
            RuleFor(contact => contact.secondaryContactNumber);
            RuleFor(contact => contact.secondaryEmail);
           

        }
    }
}