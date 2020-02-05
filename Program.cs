using System;

namespace Lab_4_Bonus
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Pig Latin Translator!");
            do
            {
                Console.Write("Please input a word or phrase: ");
                string userInput = Console.ReadLine().ToLower();
                Console.WriteLine(PigLatin(userInput));

            } while (UserContinue());
            

        }

        static string PigLatin(string word)
        {
            
            var sentence = word.Split(" ");
            string pigLatinSentence = null;
            string pigLatinString = null;

            if (word.Contains(" "))
            {
                for (int i = 0; i < sentence.Length; i++)
                {
                    pigLatinSentence += PigLatin(sentence[i]) + " ";
                }
                return pigLatinSentence;
            }

            for (int i = 0; i < word.Length; i++)
            {
                string c = word[i].ToString();
                if ("aeiouAEIOU".Contains(c))
                {
                    //If a word starts with a vowel, just add “way” onto the ending
                    if (word.IndexOf(c) == 0)
                    {
                        pigLatinString = word + "way";
                        break;
                    }
                    //If a word starts with a consonant, move all of the consonants that appear before the first vowel to the end of the word, 
                    //then add “ay” to the end of the word.
                    else
                    {
                        pigLatinString = word.Substring(word.IndexOf(c)) + word.Substring(0, word.IndexOf(c)) + "ay";
                        break;
                    }
                }
            }
            return pigLatinString;
        }

        static bool UserContinue()
        {
            char key;
            do
            {
                Console.Write("\nWould you like to order anything else? Please enter (y/n) ");
                key = Console.ReadKey().KeyChar;
                key = char.ToLower(key);
                if (key == 'n')
                {
                    return false;
                }
                Console.WriteLine();

            } while (key != 'y');
            return true;
        }
    }
}
