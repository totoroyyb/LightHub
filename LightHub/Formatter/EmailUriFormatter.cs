using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LightHub.Formatter
{
    public class EmailUriFormatter
    {
        public static string GetFormattedEmailStr(string originalStr)
        {
            return "mailto:" + originalStr;
        }
    }
}
