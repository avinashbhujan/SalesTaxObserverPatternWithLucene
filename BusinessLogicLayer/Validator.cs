using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SalesTaxObserverPattern
{
    public static class Validator
    {
        public static bool ValidateQuantity(string quantity)
        {
            Regex regex = new Regex(@"^[1-9]+$");
            Match match = regex.Match(quantity);

            if (match.Success)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool ValidatePrice(string price)
        {
            Regex regex = new Regex(@"^[1-9]+$");
            Match match = regex.Match(price);

            if (match.Success)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
