using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace day10assg12
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter a piece of text or a Paragraph:");
            string inputText = Console.ReadLine();

            int wordCount = CountWords(inputText);
            List<string> emailAddresses = ExtractEmailAddresses(inputText);
            List<string> mobileNumbers = ExtractMobileNumbers(inputText);

            Console.WriteLine($"Word Count in the above paragraph : {wordCount}");
            Console.WriteLine("Email Addresses mentioned in the above paragraph :");
            foreach (string email in emailAddresses)
            {
                Console.WriteLine(email);
            }

            Console.WriteLine("Mobile Numbers mentioned in the above paragraph:");
            foreach (string number in mobileNumbers)
            {
                Console.WriteLine(number);
            }

            Console.WriteLine("Enter a custom regular expression:");
            string customRegexPattern = Console.ReadLine();
            List<string> customRegexMatches = PerformCustomRegexSearch(inputText, customRegexPattern);

            Console.WriteLine("Custom Regex Matches the paragraph:");
            foreach (string match in customRegexMatches)
            {
                Console.WriteLine(match);
            }
        }

        static int CountWords(string text)
        {
            // Split the text by spaces and count the number of resulting substrings (words).
            string[] words = text.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            return words.Length;
        }

        static List<string> ExtractEmailAddresses(string text)
        {
            List<string> emailAddresses = new List<string>();
            // Use regex to find email addresses in the text.
            string pattern = @"[\w\.-]+@[a-zA-Z\d\.-]+\.[a-zA-Z]{2,}";
            MatchCollection matches = Regex.Matches(text, pattern);
            foreach (Match match in matches)
            {
                emailAddresses.Add(match.Value);
            }
            return emailAddresses;
        }

        static List<string> ExtractMobileNumbers(string text)
        {
            List<string> mobileNumbers = new List<string>();
            // Use regex to find 10-digit mobile numbers in the text.
            string pattern = @"\b\d{10}\b";
            MatchCollection matches = Regex.Matches(text, pattern);
            foreach (Match match in matches)
            {
                mobileNumbers.Add(match.Value);
            }
            return mobileNumbers;
        }

        static List<string> PerformCustomRegexSearch(string text, string customRegexPattern)
        {
            List<string> customRegexMatches = new List<string>();
            // Use regex to find matches based on the custom pattern.
            MatchCollection matches = Regex.Matches(text, customRegexPattern);
            foreach (Match match in matches)
            {
                customRegexMatches.Add(match.Value);
            }
            return customRegexMatches;
        }
    }
}
