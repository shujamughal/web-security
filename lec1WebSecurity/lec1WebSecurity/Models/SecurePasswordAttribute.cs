﻿using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace lec1WebSecurity.Models
{
    

    public class SecurePasswordAttribute : ValidationAttribute
    {
        private readonly int _minLength;

        public SecurePasswordAttribute(int minLength = 8)
        {
            _minLength = minLength;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value is string password)
            {
                if (password.Length < _minLength)
                {
                    return new ValidationResult($"Password must be at least {_minLength} characters long.");
                }

                if (!Regex.IsMatch(password, @"[A-Z]"))
                {
                    return new ValidationResult("Password must contain at least one uppercase letter.");
                }

                if (!Regex.IsMatch(password, @"[a-z]"))
                {
                    return new ValidationResult("Password must contain at least one lowercase letter.");
                }

                if (!Regex.IsMatch(password, @"[0-9]"))
                {
                    return new ValidationResult("Password must contain at least one digit.");
                }

                if (!Regex.IsMatch(password, @"[\W_]"))
                {
                    return new ValidationResult("Password must contain at least one special character.");
                }

                return ValidationResult.Success;
            }

            return new ValidationResult("Invalid password format.");
        }
    }


}
