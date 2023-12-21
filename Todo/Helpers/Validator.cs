using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Todo.Helpers
{
    public class Validator
    {
        public static List<string> Errors = new();

        public static void ValidatePassword(string password)
        {
            if (string.IsNullOrEmpty(password) || password.Length < 6)
                Errors.Add("Пароль должен содержать не менее 6 символов");
        }

        public static void ValidateName(string name)
        {
            if (string.IsNullOrEmpty(name) || name.Length < 3)
                Errors.Add("Имя должно иметь не менее 3 знаков");
        }

        public static void ValidateEmail(string email)
        {
            if (!Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$", RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250)))
                Errors.Add("Email должен содержать следующие символы \".\", \"@\"");
        }

        public static void PasswordsEquality(string password, string passwordConfirm)
        {
            if (!string.Equals(password, passwordConfirm))
                Errors.Add("Пароли различаются");
        }
    }
}
