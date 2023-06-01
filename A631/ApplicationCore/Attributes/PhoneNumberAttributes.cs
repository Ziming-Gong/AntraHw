using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace ApplicationCore.Attributes;

public class PhoneNumberAttributes : ValidationAttribute
{
    public override bool IsValid(object  str)
    {
        if (str == null)
        {
            return false;
        }
        
        string phoneNumber = Convert.ToString(str);
        // Regular expression pattern for a basic phone number format
        string pattern = @"^\d{3}-\d{3}-\d{4}$";

        // Validate the phone number against the pattern
        if (!Regex.IsMatch(phoneNumber, pattern)){
            return false;
        }

        return true;
    }
}