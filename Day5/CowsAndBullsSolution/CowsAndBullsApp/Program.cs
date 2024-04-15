using System.Runtime.Intrinsics.X86;
using System.Text.RegularExpressions;

namespace CowsAndBullsApp
{
    internal class Program
    {
        static bool getString(string input, out string name)
        {
            name = "";
            string pattern = @"^[a-zA-Z\s]+$";

            bool patternMatch = Regex.IsMatch(input, pattern);

            if (patternMatch && input.Length==4)
            {
                name = input;
                return true;
            }
            return false;


        }

        static void PrintAllGuess(string[] gussess)
        {
            Console.WriteLine("Your Guess words are...");
            for(int i = 0; i < gussess.Length; i++)
            {
                Console.WriteLine(gussess[i] );
            }

        }

        static void CowsAndBulls()
        {
            string[] gussess = new string[10];
            Console.WriteLine("Enter secret word");
            string target;
            while(!getString(Console.ReadLine(),out target))
            {
                Console.WriteLine("Enter a valid secret word");
            }
            int cows = 0;
            int bulls = 0;
            string guess;
            int cnt = 0;
            int j = 0;
            while(cows!=4)
            {
                Console.WriteLine("Guess the word");
                cows = 0;
                bulls = 0;
                while(!getString(Console.ReadLine(),out guess))
                {
                    Console.WriteLine("Invalid string, Guess again");
                }
                gussess[j] = guess;
                for(int i = 0; i < 4; i++)
                {
                    if (target.Contains(guess[i]))
                    {
                        bulls++;
                    }
                    if (guess[i] == target[i])
                    {
                        cows++;
                    }

                }
                bulls = bulls - cows;
                Console.WriteLine($"Cows\t:{cows}");
                Console.WriteLine($"Bulls\t:{bulls}\n");
                cnt++;
               j++;
            }

            Console.WriteLine($"Congratulations you found the word at attempt {cnt}");
            PrintAllGuess(gussess);


        }

        static void Main(string[] args)
        {
            CowsAndBulls();

        }
    }
}
