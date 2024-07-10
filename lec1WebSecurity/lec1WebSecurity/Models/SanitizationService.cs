using System.Text.RegularExpressions;

namespace lec1WebSecurity.Models
{
    public class SanitizationService : ISanitizationService
    {
        public string SanitizeInput(string input)
        {
            // Example sanitization logic (remove script tags)
            return Regex.Replace(input, "<.*?>", string.Empty);
        }
    }

}
