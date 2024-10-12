using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace BitsAndBots.Validators
{
    public class TagValidator : ValidationAttribute
    {
        public override bool IsValid(object? value)
        {
            return !Regex.Match(value.ToString(), @"\s").Success;
        }
    }
}
