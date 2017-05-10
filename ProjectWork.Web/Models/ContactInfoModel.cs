using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using ProjectWork.Web.Infrastructure.Validators;

namespace ProjectWork.Web.Models
{
    public class ContactData
    {
        public string name { get; set; }
        public string primaryEmail { get; set; }
        public string secondaryEmail { get; set; }
        public string addressPermanent { get; set; }
        public string addressCorrespondance { get; set; }
        public string primaryContactNumber { get; set; }
        public string secondaryContactNumber { get; set; }
    }

    public class ContactInfoModel
    {
        public List<ContactData> contactInfos { get; set; }
    }

    //public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    //{
    //    var validator = new ContactInfoModelValidators();
    //    var result = validator.Validate(this);
    //    return result.Errors.Select(item => new ValidationResult(item.ErrorMessage, new[] { item.PropertyName }));
    //}
}