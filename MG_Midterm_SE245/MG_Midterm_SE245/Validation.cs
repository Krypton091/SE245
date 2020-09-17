using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MG_Midterm_SE245
{
    class Validation
    {
        public static bool IsItFilledIn(string temp)
        {
            bool result = false;

            if (temp.Length > 0)
            {
                result = true;
            }

            return result;
        }

        public static bool IsItFilledIn(string temp, int minlen)
        {
            bool result = false;

            if (temp.Length >= minlen)
            {
                result = true;
            }

            return result;
        }

        public static bool IsValidEmail(string temp)
        {
            //assume true, but look for bad stuff to make it false
            bool blnResult = true;

            //Look for position of "@"
            int atLocation = temp.IndexOf("@");
            int NextatLocation = temp.IndexOf("@", atLocation + 1);

            //temp = scott@neit.ca
            // length = 13
            // position of last period = 10

            //Look for position of last period "."
            int periodLocation = temp.LastIndexOf(".");

            //check for minimum length, but also allow a blank field
            if (temp.Length < 8 && temp.Length > 0)
            {
                blnResult = false;
            }
            else if (atLocation < 2)    //if it is -1, not found and needs at least 2 chars in front
            {
                blnResult = false;
            }
            else if (periodLocation + 2 > (temp.Length))
            {
                blnResult = false;
            }

            return blnResult;
        }

    }
}
