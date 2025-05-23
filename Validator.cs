using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaydayFranchiseRandomHeistSelecter
{
    internal class Validator
    {
        public static string IsValidInt(string tester)
        {
            string msg = "";
            if (!int.TryParse(tester, out int value))
            {
                msg += "must be a valid number";

            }
            else if (int.TryParse(tester, out value))
            {
                if (value < 1)
                {
                    msg += "number must be 1 or greater";
                }
            }
            return msg;
        }
    }
}
