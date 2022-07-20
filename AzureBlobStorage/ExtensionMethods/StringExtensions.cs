using System.Globalization;
using System.Text.Json;

namespace AzureBlobStorage.ExtensionMethods
{
    public static class StringExtensions
    {
        public static bool IsJson(this string source)
        {
            if (source == null)
                return false;

            try
            {
                JsonDocument.Parse(source);
                return true;
            }
            catch (JsonException)
            {
                return false;
            }
        }

        public static decimal ToDecimal(this string str)
        {
            return decimal.Parse(str, CultureInfo.CurrentCulture);
        }

    }
}
