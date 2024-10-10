using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace BitsAndBots.Validators
{
    public class UrlValidator : ValidationAttribute
    {
        public override bool IsValid(object? value)
        {
            if (value == null)
            {
                return true;
            }
            return Regex.Match(value.ToString(), @"^https?:\/\/.+", RegexOptions.IgnoreCase).Success;
        }
    }
}
