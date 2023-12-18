using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace Kaosearch.Models.Validation {
   public class TextOnlyAttribute : ValidationAttribute
{
 public override bool IsValid(object value)
 {
     if (value is string str) 
     {
         string regex = @"^[a-zA-Z]+$";
         return Regex.IsMatch(str, regex);
     }
     return false;
 }
}
}
