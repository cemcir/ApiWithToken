using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ApıWithToken.DataControl
{
    public class ProductDataControl
    {
        public static bool validateProductName(string productName)
        {
            Regex regex = new Regex(@"^[a-zA-ZğüşıöçĞÜŞİÖÇ]{2,}$");
            Regex regex1 = new Regex(@"^\(?([a-zA-ZğüşıöçĞÜŞİÖÇ]{2,})\)?[ ]?([a-zA-ZğüşıöçĞÜŞİÖÇ]{2,})$");
            if (regex.IsMatch(productName) || regex1.IsMatch(productName))
            {
                return true;
            }
            return false;
        }

        public static bool validateProductCategory(string category)
        {
            Regex regex = new Regex(@"^[a-zA-ZğüşıöçĞÜŞİÖÇ]{2,}$");
            Regex regex1 = new Regex(@"^\(?([a-zA-ZğüşıöçĞÜŞİÖÇ]{2,})\)?[ ]?([a-zA-ZğüşıöçĞÜŞİÖÇ]{2,})$");
            if (regex.IsMatch(category) || regex1.IsMatch(category))
            {
                return true;
            }
            return false;
        }
 
        public static bool validateProductPrice(decimal? productPrice){
            Regex regex = new Regex(@"^[0-9]{1,}$");
            if (regex.IsMatch(productPrice.ToString())){
                String s = productPrice.ToString();
                char[] array = s.ToCharArray();
                if (array[0]=='0' || array[0]==' ' || productPrice<1){
                    return false;
                }
                return true;
            }
            return false;
        }

        public static string updateProductName(string productName)
        {
            productName = productName.ToLower();
            return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(productName);
        }

        public static string updateCategoryName(string category)
        {
            category = category.ToLower();
            return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(category);
        }
 
    }
}
