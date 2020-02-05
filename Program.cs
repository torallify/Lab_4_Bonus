using System;
using System.Text.RegularExpressions;

namespace Lab_4_Bonus
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Pig Latin Translator!");
            do
            {
                Console.Write("\nPlease input a word or phrase: ");
                string userInput = Console.ReadLine();
                Console.WriteLine($"\n{PigLatin(userInput)}");

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

            if (Regex.IsMatch(word, @"^[a-zA-Z']+$"))
            {
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
                    else
                    {
                        pigLatinString = word;
                    }
                }
            }
            
            else
            {
                int specialCharacterIndex;
                string specialChaEndings = @"\|!#$%&/()=?»«@£§€{}.-;<>_,";
                foreach (var item in specialChaEndings)
                {
                    if (word.Contains(item) && (word.IndexOf(item) == (word.Length - 1)))
                    {
                        specialCharacterIndex = word.IndexOf(item);
                        pigLatinString = word.Substring(0, specialCharacterIndex);

                        pigLatinString = PigLatin(pigLatinString) + word.Substring(specialCharacterIndex);
                    }
                    
                    else if (word.Contains(item))
                    {
                        pigLatinString = word;
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
