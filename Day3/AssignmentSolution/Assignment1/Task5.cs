using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Assignment1
{
    internal class Task5
    {

        static bool getName(string input, out string name) {
            name = "";
            string pattern = @"^[a-zA-Z\s]+$";

            bool patternMatch = Regex.IsMatch(input, pattern);

            if(patternMatch) { 
                name = input;
                return true;
            }
            return false;


        }

        static bool getPassword(string input, out string pass)
        {
            pass = "";
            if(input.Trim().Length == 0) { 
                return false;
            }
            pass = input.Trim();
            return true;

        }

        static bool validate(string name, string password, out string message)
        { message = "The user name and password do not match. Try again";
            if(name == "ABC" &&  password == "123")
            {
                message = "User has been authenticated successfully";
                return true;
            }
            return false;
        }

        static void PrintInfo( string msg)
        {
            Console.WriteLine(msg);
        }

        static void authenticateUser()
        {
            string name;
            string password;
            int cnt = 0;
            string message;
            Console.WriteLine("Enter User name");
            while (cnt < 3)
            {
                while(!getName(Console.ReadLine(), out name))
                {
                    Console.WriteLine("Invalid User Name. Type Correct User name");
                }
                Console.WriteLine("Enter Password");
                //password = Console.ReadLine().Trim();

                while(!getPassword(Console.ReadLine(), out password))
                {
                    Console.WriteLine("Password is Empty. Type a password");
                }

                if (!validate(name, password,out message)) {
                    PrintInfo(message);
                    cnt++;
                }
                else
                {
                    PrintInfo(message);
                    break;
                }


            }
            if(cnt>=3)
            {
                message = "The trial exceeded 3 attempts. Try again after some time";
                PrintInfo(message);
            }


        }


        static void Main(string[] args)
        {

            authenticateUser();

        }
    }
}
