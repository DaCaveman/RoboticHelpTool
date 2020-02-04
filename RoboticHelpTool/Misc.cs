using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoboticHelpTool
{
    public static class Misc
    {
		//Bool, ob "string" gleich "StrINg" ist
        public static bool CaseInsensitiveContains(this string text, string value,
                            StringComparison stringComparison = StringComparison.CurrentCultureIgnoreCase)
        {
            return text.IndexOf(value, stringComparison) >= 0;
        }

    }
}
