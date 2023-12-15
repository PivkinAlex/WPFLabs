using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Desktop
{
    public class Validator
    {
        public static bool PassValid(PasswordBox passtb)
        {
            if (passtb.Password.Length < 6) 
                return false;
            else 
                return true;
        }

        public static bool EmailValid(TextBox mailtb)
        {
            Regex regex = new Regex(@"^([\w.-]+)@([\w-]+)((.(\w){2,3})+)$");
            Match match = regex.Match(mailtb.Text);

            if (match.Success) 
                return true;
            else 
                return false;
        }

        public static bool NameValid(TextBox name)
        {
            if (name.Text.Length > 3) 
                return true;
            else 
                return false;
        }

        public static bool CheckPassValid(PasswordBox pass1, PasswordBox pass2)
        {
            if (pass1 == pass2) 
                return true;
            else 
                return false;
        }

    }
}
