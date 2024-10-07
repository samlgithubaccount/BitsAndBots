using System.ComponentModel.DataAnnotations;

namespace BitsAndBots.Validators
{
    public class FutureDateTimeValidator : ValidationAttribute
    {
        public override bool IsValid(object? value)
        {
            if (value == null)
            {
                return true;
            }

            var dateTime = (DateTime)value;

            if (dateTime <= DateTime.Now)
            {
                return false;
            }
            return true;
        }
    }
}
