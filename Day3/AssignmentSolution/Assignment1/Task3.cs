using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1
{
    internal class Task3
    {
        static bool TakeNum(out int num)
        {
            Console.WriteLine("Enter the numbers you want to Average");

            while (!int.TryParse(Console.ReadLine(), out num))
            {
                Console.WriteLine("Invalid number enter again");
            }

            return checkNegative(num);

        }

        static bool checkNegative(int num)
        {
            if ((num >= 0)  )
            {
                return true;
            }
            return false;
        }

        static void PrintInfo(int sum, int cnt) {
            try
            {
                Console.WriteLine("The Average is : " + average(sum, cnt));
            }
            catch (Exception)
            {
                Console.WriteLine("The are no numbers divisible by 7, so average cannot be calculated");
               
            }
            
        }

        static double average(int num, int cnt) { 
            return (double)(num/ cnt);
        }
           
        static void calculateAverage()
        {
            int num;
            int cnt = 0;
            int sum = 0;
            while (TakeNum(out num))
            {
                if (num % 7 == 0)
                {
                    sum = sum + num;
                    cnt++;
                }


            }
            PrintInfo(sum, cnt);
        }

        static void Main(string[] args)
        {

            calculateAverage();
            



        }

    }
}
