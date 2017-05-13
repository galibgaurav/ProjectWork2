using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using ProjectWork.Web.Infrastructure.Validators;

namespace ProjectWork.Web.Models
{
    public class StateViewModel
    {
      
        public string StateName { get; set; }
        public int ContactInfoDetails_ID { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var validator = new StateViewModelValidators();
            var result = validator.Validate(this);
            return result.Errors.Select(item => new ValidationResult(item.ErrorMessage, new[] { item.PropertyName }));
        }
    }
}