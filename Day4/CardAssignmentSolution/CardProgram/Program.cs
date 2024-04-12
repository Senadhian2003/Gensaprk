using System.Text.RegularExpressions;

namespace CardProgram
{
    class Program
    {
      
        /// <summary>
        /// Get String value and validate for length and regex pattern
        /// </summary>
        /// <param name="input">Input string to be validated</param>
        /// <param name="output">Final formatted string</param>
        /// <returns></returns>
        static bool getString(string input, out string output)
        {
            output = input;

            string pattern = @"^[0-9]+$";

            if(Regex.IsMatch(input, pattern) && input.Trim().Length==16) { 
            
            output = input.Trim();
            return true;
            }

            return false;

        }

        /// <summary>
        /// Reverse the card number
        /// </summary>
        /// <param name="input">Original Card number</param>
        /// <returns></returns>
        static string reverseCardNumber(string input)
        {

            string reversed = String.Empty;

            for (int i = input.Length-1; i >= 0; i--)
            {
                reversed += input[i];
            }
            return reversed;
        }

        /// <summary>
        /// Calculate the sum of card number
        /// </summary>
        /// <param name="input">Reversed card number</param>
        /// <returns></returns>
        static int calculateSum(string input)
        {
            int sum = 0;
            int value;
            int digitsum;
            for (int i = 0; i < input.Length; i++)
            {
                digitsum = 0;
                value = Convert.ToInt32(input[i]) - '0';
                if (i % 2 == 0)
                {
                    sum += value;
                }
                else
                {

                    value = (value * 2);
                    while (value > 0)
                    {
                        int r = value % 10;
                        digitsum += r;
                        value /= 10;
                    }
                    sum += digitsum;

                }

            }
            return sum;
        }

        /// <summary>
        /// Print Validity of card
        /// </summary>
        /// <param name="total">Total value</param>
        static void printResult(int total)
        {
            if (total % 10 == 0) {
                Console.WriteLine("Valid Card number");

            }
            else
            {
                Console.WriteLine("Invalid Card number");
            }
        }

        static void Main(string[] args)
        {

            string cardNumber;
            Console.WriteLine("Enthe the Card number");
            while (!getString(Console.ReadLine(), out cardNumber)) {

                Console.WriteLine("Invalid Card number, the length of card number must be 16. Type again");

            }

            //Console.WriteLine(cardNumber);

            string reversedCardNumber = reverseCardNumber(cardNumber);

            //Console.WriteLine(reversedCardNumber);

            int total = calculateSum(reversedCardNumber);
            //Console.WriteLine(total);
            printResult(total);

            


        }
    }
}
