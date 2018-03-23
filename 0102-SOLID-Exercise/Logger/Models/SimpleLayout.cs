using Logger.Models.Contracts;
using System.Globalization;

namespace Logger.Models
{
    public class SimpleLayout : ILayout
    {
        const string DateFormat = "M/d/yyyy h:mm:ss tt";
        const string Format = "{0} - {1} - {2}";

        public string FormatError(IError error)
        {
            string dateString = error.DateTme.ToString(DateFormat, 
                CultureInfo.InvariantCulture);

            string formattedError = string.Format(Format, dateString, error.Level, error.Message);

            return formattedError;
        }
    }
}
