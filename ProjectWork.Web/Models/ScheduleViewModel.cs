using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using ProjectWork.Entities;
using ProjectWork.Web.Infrastructure.Validators;

namespace ProjectWork.Web.Models
{
    public class ScheduleViewModel
    {
        public string ScheduleTime { get; set; }
        public string UserID { get; set; }
        public List<int> ContactInfoIDs { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var validator = new ScheduleViewModelValidators();
            var result = validator.Validate(this);
            return result.Errors.Select(item => new ValidationResult(item.ErrorMessage, new[] { item.PropertyName }));
        }
    }
}