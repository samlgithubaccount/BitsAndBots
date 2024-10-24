﻿using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace BitsAndBots.Validators
{
    public class UsernameCharacterValidator : ValidationAttribute
    {
        public override bool IsValid(object? value)
        {
            if (value == null)
            {
                return true;
            }
            return Regex.Match(value.ToString(), @"^[a-zA-Z0-9-_]*$").Success;
        }
    }
}
