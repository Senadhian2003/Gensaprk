using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Assignment1
{
    internal class Task7
    {
        static string getString()
        {
            return Console.ReadLine().Trim();
        }

        static void findWordWithLessVowel()
        {
            Console.WriteLine("Enter the data");
            string data = getString();

            string[] list = data.Split(',');
            int minVowCount = int.MaxValue - 1;
            int vowCount;
            string vowel = "aeiouAEIOU";
            Dictionary<string, int> hist = new Dictionary<string,int>();
            foreach (string word in list)
            {
                vowCount = 0;   
                foreach(char character in word) { 
                    
                    if(vowel.Contains(character))
                    {
                        vowCount++;
                    }
                    //Console.WriteLine(vowCount);

                }

                if(vowCount <= minVowCount) { 
                    minVowCount = vowCount;
                    
                    hist.Add(word, vowCount);

                }


            }

            foreach (KeyValuePair<string, int> pair in hist)
            {
                if (pair.Value == minVowCount)
                {
                    Console.WriteLine($"The word is {pair.Key} and count is {pair.Value}");
                }
               

            }

        }

        static void Main(string[] args)
        {
            
            findWordWithLessVowel();

        }


    }
}
