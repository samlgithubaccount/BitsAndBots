using System.ComponentModel.DataAnnotations;

namespace BitsAndBots.Validators
{
    public class FutureDateTimeValidator : ValidationAttribute
    {
        private readonly string existingTimePropertyName;
        public FutureDateTimeValidator(string existingTimePropertyName)
        {
            this.existingTimePropertyName = existingTimePropertyName;
        }

        protected override ValidationResult IsValid(object? value, ValidationContext validationContext)
        {
            if (value == null)
            {
                return ValidationResult.Success;
            }

            var existingTimeProperty = validationContext.ObjectType.GetProperty(existingTimePropertyName);
            var existingTime = (DateTime)existingTimeProperty.GetValue(validationContext.ObjectInstance);

            var dateTime = (DateTime)value;

            if (dateTime != existingTime && dateTime <= DateTime.Now)
            {
                return new ValidationResult($"{validationContext.DisplayName} must be in the future.", new List<string> { validationContext.MemberName });
            }
            return ValidationResult.Success;
        }
    }
}
