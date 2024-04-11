using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1
{
    internal class Task2
    {
        static int compare(int num1, int num2)
        {
            if (num1 >= num2)
            {
                return num1;
            }
            return num2;
        }

        static bool TakeNum(out int num)
        {   
            Console.WriteLine("Enter the numbers you want to comapare");
            
            while (!int.TryParse(Console.ReadLine(),out num))
            {
                Console.WriteLine("Invalid number enter again");
            }

            return checkNegative(num);

        }

        static bool checkNegative(int num)
        {
            if (num >= 0)
            {
                return true;
            }
            return false;
        }

        static void findMax()
        {
            int maxnum = 0;
            int num;
            while (TakeNum(out num))
            {

                maxnum = compare(maxnum, num);
            }
            printInfo(maxnum);

        }

        static void printInfo(int num)
        {
            Console.WriteLine($"MaxNumber is {num}");
        }

        static void Main(string[] args)
        {
            findMax();

            
            
        }

        }
    }
