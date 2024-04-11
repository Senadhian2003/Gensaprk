using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Assignment1
{
    internal class Task4
    {
        static bool getName(string input, out string name)
        {
            name = "";
            string pattern =  @"^[a-zA-Z\s]+$";

            bool patternMatch = Regex.IsMatch(input, pattern);

            if (patternMatch)
            {
                name = input;
                return true;
            }
            return false;


        }
        static string trimmer(string name)
        {
            return name.Trim();
        }
        static int findLength(string name)
        {   
            return trimmer(name).Length;
        }

        static void PrintInfo(int len)
        {
            if(len == 0)
            {
                Console.WriteLine("The User Name is Empty, The length is 0");
            }
            else
            {
                Console.WriteLine($"The length of user Name is {len}");
            }
        }

         static void getStringLength()
        {
            string name;
            Console.WriteLine("Enter User name");
            while(!getName(Console.ReadLine(), out name))
            {
                Console.WriteLine("The User name is inappropriate. Type Correct User name");
            }

            PrintInfo(findLength(name));

        }

        static void Main(string[] args)
        {
            getStringLength();

        }


    }
}
