using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ApıWithToken.DataControl
{
    public class UserDataControl
    {
        
        public static bool validateSurName(string surName)
        {
            Regex regex = new Regex(@"^[a-zA-ZğüşıöçĞÜŞİÖÇ]{2,}$");
            if (regex.IsMatch(surName))
            {
                return true;
            }
            return false;
        }

        public static bool validateName(string name)
        {
            Regex regex = new Regex(@"^[a-zA-ZğüşıöçĞÜŞİÖÇ]{3,}$");
            Regex regex1 = new Regex(@"^\(?([a-zA-ZğüşıöçĞÜŞİÖÇ]{3,})\)?[ ]?([a-zA-ZğüşıöçĞÜŞİÖÇ]{3,})$");
            if (regex.IsMatch(name) || regex1.IsMatch(name))
            {
                return true;
            }
            return false;
        }

        public static bool validateEmail(string email)
        {
            Regex regex = new Regex(@"^([a-zA-Z0-9_\.\-])+\@(hotmail.com|gmail.com|outlook.com)+$");
            if (regex.IsMatch(email))
            {
                return true;
            }
            return false;
        }

        public static bool validatePassword(string password)
        {           
            Regex regex1 = new Regex(@"[a-z]");
            Regex regex2 = new Regex(@"[A-Z]");
            Regex regex3 = new Regex(@"[0-9]");
            //Regex regex4 = new Regex(@"[+*@_.\?]");
            if(regex1.IsMatch(password)==false || regex2.IsMatch(password)==false || regex3.IsMatch(password)==false || password.Length!=8)
            {
                return false;
            }
            return true;
            
        }

        public static string updateName(string name)
        {
            string names=null;
            string[] str = name.Split(' ');
            if (str.Length > 1)
            {
                for (int i = 0; i < str.Length; i++)
                {
                    str[i] = str[i].ToLower();
                    names = names+" "+CultureInfo.CurrentCulture.TextInfo.ToTitleCase(str[i]);
                }
                return names;
            }
            else
            {
                name = name.ToLower();
                return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(name);
            }
        }

        public static string updateSurName(string surName)
        {
            return surName.ToUpper(new CultureInfo("tr-TR", false));
        }
    }
}
