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
