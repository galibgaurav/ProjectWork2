using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FluentValidation;
using ProjectWork.Web.Models;

namespace ProjectWork.Web.Infrastructure.Validators
{
    public class ContactInfoModelValidators: AbstractValidator<ContactInfoModel>
    {
        public ContactInfoModelValidators()
        {
            RuleFor(contact => contact.Name).NotEmpty().NotNull().Length(1,50).WithMessage("Name must be between 1 - 50 characters") ;
            RuleFor(contact => contact.AddressCorrespondance).NotNull().Length(10, 100).WithMessage("Correspondence address must be between 1 - 100 characters");
            RuleFor(contact => contact.AddressPermanent).NotNull().Length(10, 100).WithMessage("Permanent address must be between 1 - 100 characters");
            RuleFor(contact => contact.PrimaryContactNumber).NotNull();
            RuleFor(contact => contact.PrimaryEmail);
            RuleFor(contact => contact.SecondaryContactNumber);
            RuleFor(contact => contact.SecondaryEmail);
           

        }
    }
}