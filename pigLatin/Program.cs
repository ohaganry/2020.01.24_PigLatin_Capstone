using System;
using System.Text;
using System.Collections.Generic;

namespace pigLatin
{
    class Program
    {
        static void Main(string[] args)
        {
            string userInput = GetUserInput("Enter your phrase:").ToLower();
            string pigLatin = ToPigLatin(userInput);
            Console.WriteLine(pigLatin);
        }
        public static string GetUserInput(string message)
        {
            Console.WriteLine(message);
            return Console.ReadLine();
        }
        public static bool ValidateInput()
        {
            string usertInput = GetUserInput("Would you like to proceed? ").ToLower();
            if(usertInput == "y")
            {
                return true;
            }
            else if(usertInput == "n")
            {
                return false;
            }
            else
            {
                return ValidateInput();
            }
        }
        public static string ToPigLatin(string input)
        {
            string vowels = "aeiou";
            List<string> newWords = new List<string>();
            foreach(string word in input.Split())
            {
                if(word.Length == 1)
                {
                    newWords.Add(word + "way");
                }
                if(word.Length == 2 && vowels.Contains(word[0]))
                {
                newWords.Add(word + "ay");
                }

                if (word.Length == 2 && vowels.Contains(word[1]) && !vowels.Contains(word[0]))
                {
                    newWords.Add(word.Substring(1) + word.Substring(0, 1) + "ay");
                }

                if (word.Length == 2 && !vowels.Contains(word[1]) && !vowels.Contains(word[0]))
                {
                    newWords.Add(word + "ay");
                }                

                for (int i = 1; i < word.Length; i++)
                {
                    if (vowels.Contains(word[i]) && (vowels.Contains(word[0])))
                    {
                    newWords.Add(word.Substring(i) + word.Substring(0, i) + "ay");
                    break;
                    }
                 }

                for (int i = 0; i < word.Length; i++)
                {
                if (vowels.Contains(word[i]) && !(vowels.Contains(word[0])) && word.Length > 2)
                {
                    newWords.Add(word.Substring(i) + word.Substring(0, i) + "ay");
                    break;
                }

                }
                    
                         
            }
            return string.Join(" ", newWords);
        }
    }
}
