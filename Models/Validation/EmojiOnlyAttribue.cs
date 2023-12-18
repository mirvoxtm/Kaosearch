using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace Kaosearch.Models.Validation {
public class EmojiOnlyAttribute : ValidationAttribute
{
  public override bool IsValid(object value)
  {
      if (value is string str) 
      {
          string regex = @"\p{So}|\p{Cs}\p{Cs}(\p{Cf}\p{Cs}\p{Cs})*";
          return Regex.IsMatch(str, regex);
      }
      return false;
  }
} 
    }