using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace PeriodProjectionSrc
{
    public class PeriodProjection
    {
        private readonly Regex rx = new Regex(@"[a-zA-Z]+");

        private static string SanitizeInput(string period)
        {
            return HttpUtility.HtmlEncode(period.ToUpper());
        }

        public List<string> GetLetters(string input)
        {
            //Use Regular Expression to get all letters
            return rx.Matches(input)
                .OfType<Match>()
                .Select(m => m.Value)
                .ToList();
        }

        public string[] GetDigits(string input)
        {
            //Use Regular Expression to split the period on each letter
            return rx.Split(input);
        }

#if NET6_0_OR_GREATER
        private DateOnly CalculateDate(DateOnly input, string period)
#else
        private DateTime CalculateDate(DateTime input, string period)
#endif
        {
            //Sanitize input string
            string sanitizedInput = SanitizeInput(period);

            //Basic validations
            if (sanitizedInput == null)
                return input;

            if (sanitizedInput.Length == 0)
                return input;

            //Extract values using Regular Expression

            var letters = GetLetters(sanitizedInput);
            var digits = GetDigits(sanitizedInput);

            //Check for incorrect inputs: duplicates are not accepted
            if (letters.Distinct().Count() != letters.Count)
                return input;

#if NET6_0_OR_GREATER
            foreach (var item in letters)
            {
                input = item switch
                {
                    "Y" => input.AddYears(int.TryParse(digits[letters.IndexOf("Y")], out int valY) ? valY : 0),
                    "M" => input.AddMonths(int.TryParse(digits[letters.IndexOf("M")], out int valM) ? valM : 0),
                    "W" => input.AddDays(int.TryParse(digits[letters.IndexOf("W")], out int valW) ? valW * 7 : 0), //rough simplification for now
                    "D" => input.AddDays(int.TryParse(digits[letters.IndexOf("D")], out int valD) ? valD : 0),
                    _ => input
                };
            }
#else
            foreach (var item in letters)
            {
                switch (item)
                {
                    case "Y": 
                        input = input.AddYears(int.TryParse(digits[letters.IndexOf("Y")], out int valY) ? valY : 0);
                        break;
                    case "M": 
                        input = input.AddMonths(int.TryParse(digits[letters.IndexOf("M")], out int valM) ? valM : 0);
                        break;
                    case "W": 
                        input = input.AddDays(int.TryParse(digits[letters.IndexOf("W")], out int valW) ? valW * 7 : 0); //rough simplification for now
                        break;
                    case "D": 
                        input = input.AddDays(int.TryParse(digits[letters.IndexOf("D")], out int valD) ? valD : 0);
                        break;
                    default:
                        break;
                };
            }
#endif

            return input;
        }

#if NET6_0_OR_GREATER
        //.Net 6 compatible method
        public (DateOnly, DateOnly) GetValidPeriod(DateOnly currentDate, string pastPeriod, string futurePeriod)
        {
            return (CalculateDate(currentDate, pastPeriod), CalculateDate(currentDate, futurePeriod));
        }
#else
        //Method for legacy .NET versions or in any case to use DateTime
        public (DateTime, DateTime) GetValidPeriod(DateTime currentDate, string pastPeriod, string futurePeriod)
        {
            return (CalculateDate(currentDate, pastPeriod), CalculateDate(currentDate, futurePeriod));
        }
#endif
    }
}
