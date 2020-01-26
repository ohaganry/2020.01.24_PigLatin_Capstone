using System;
using System.Text;
using System.Collections.Generic;

namespace pigLatin
{
    class Program
    {
        static void Main(string[] args)
        {
            bool proceed = true;
            while(proceed)
            {
            string userInput = GetUserInput("Enter your phrase:").ToLower();
            string pigLatin = ToPigLatin(userInput);
            Console.WriteLine(pigLatin);
            proceed = ValidateInput();
            }
            Console.WriteLine("ood-gay ye-bay");

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
            //vowels variable used to run through string
            string vowels = "aeiou";
            //create list of strings to join after translation
            List<string> newWords = new List<string>();
            //foreach runs through each word in the input .Split breaks the sentence into individual words
            foreach(string word in input.Split())
            {
                //for single letter words add -way to the end since single letter words are a & I
                if(word.Length == 1 || vowels.Contains(word[0]) && word.Length > 2)
                {
                    // adds converted word to List
                    newWords.Add(word + "-ay");
                }
                //for two letter words that start with a vowel (ex. am, I'm, an, in, etc.) or has no vowels adds -ay
                if((word.Length == 2 && vowels.Contains(word[0])) || (word.Length == 2 && !vowels.Contains(word[0]) && !vowels.Contains(word[1])))
                {
                    //adds converted word to list
                    newWords.Add(word + "ay");
                }
                //for two letter words that end with a vowel (ex. to, do, so, etc.)
                if (word.Length == 2 && vowels.Contains(word[1]) && !vowels.Contains(word[0]))
                {
                    //takes index (1) and places it infornt of index (2) and ends with -ay and adds to list
                    newWords.Add(word.Substring(1) + "-" + word.Substring(0, 1) + "ay");
                }
                for (int i = 0; i < word.Length; i++)
                {
                    //looks for index of first vowel & confirms it is not in index [0] & that the word is more than 2 letters long
                    if (vowels.Contains(word[i]) && (!vowels.Contains(word[0])) && word.Length > 2)
                    {
                        //cuts the word from vowel index to end of string & adds on indexes before vowel to the end & adds ay to the end
                        newWords.Add(word.Substring(i) + "-" + word.Substring(0, i) + "ay");
                        break;
                    }
                    //for any words 
                    //if(vowels.Contains(word[0]) && word.Length > 2)
                    //{
                        //newWords.Add(word + "way");
                        //break;
                    //}
                }        
            }
            return string.Join(" ", newWords);
        }
    }
}
