using System;
using System.Text;
using System.Collections.Generic;

namespace PigLatin_MethodRebuild
{
    class Program
    {
        static void Main(string[] args)
        {
            bool proceed = true;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Welcome to the Pig Latin Translator");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("===================================");
            while(proceed)
            {
                string[] input = (GetUserInput("Input what you want translated:").ToLower()).Split();
                Console.WriteLine("\nTranslation:");
                foreach(string s in input)
                {
                        string newWord = ToPigLatin(s);
                        Console.Write(newWord);
                }
                Console.WriteLine("\n");
                proceed = ValidateInput();
            }
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nood-gay ye-bay");
        }
        
        public static string ToPigLatin(string word)
        {
            int index;
            string firstPart;
            string secondPart;
            char[] vowels = "aeiou".ToCharArray();
            string vowel = "aeiou";
            if(word.Length == 1)
            {
                return (word + "-yay ");
            }
            if(word.Length == 2 && vowel.Contains(word[0]))
            {
                return (word + "-ay ");
            }
            if(word.Length == 2 && vowel.Contains(word[1]))
            {
                return (word[1] + "-" + word[0] +"ay ");
            }
            if(!word.Contains(vowel[0]) && !word.Contains(vowel[1]) && !word.Contains(vowel[2]) && !word.Contains(vowel[3]) && !word.Contains(vowel[4]))
            {
                index = word.IndexOf('y');
                firstPart = word.Substring(index);
                secondPart = word.Substring(0, index);
                return (firstPart + "-" + secondPart + "ay ");  
            }
            else
            {
                index = word.IndexOfAny(vowels);
                firstPart = word.Substring(index);
                secondPart = word.Substring(0, index);
                return (firstPart + "-" + secondPart + "ay ");
            }
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
                Console.WriteLine("\n===================================");
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
    }
}
