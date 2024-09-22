using System.ComponentModel.DataAnnotations;

namespace BitsAndBots.Validators
{
    public class EndTimeValidator : ValidationAttribute
    {
        private readonly string startTimePropertyName;

        public EndTimeValidator(string startTimePropertyName)
        {
            this.startTimePropertyName = startTimePropertyName;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var endTime = (DateTime)value;

            var startTimeProperty = validationContext.ObjectType.GetProperty(startTimePropertyName);
            var startTime = (DateTime)startTimeProperty.GetValue(validationContext.ObjectInstance);

            if (endTime <= startTime)
            {
                return new ValidationResult("End time must be after Start time.", new List<string> { "EndTime" });
            }

            return ValidationResult.Success;
        }
    }
}
