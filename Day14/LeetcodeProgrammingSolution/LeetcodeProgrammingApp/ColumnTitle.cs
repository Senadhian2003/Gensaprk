using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetcodeProgrammingApp
{
    internal class ColumnTitle
    {

        public async Task <string> ColumnResult(int value)
        {

            if (value <= 26)
            {

                return Convert.ToChar(64 + value).ToString();
            }
            else
            {
                int division = value / 26;
                int remainder = value % 26;
                if (remainder == 0)
                {
                    remainder = 26;
                    division--;
                }
                return await ColumnResult(division) + Convert.ToChar(64 + remainder).ToString();
            }




        }


        async void FindColumn()
        {

            Console.WriteLine("Enter the number");
            int columnNumber = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("The Column Title is "+ await ColumnResult(columnNumber));

        }


        static void Main(string[] args)
        {

            ColumnTitle columnTitle = new ColumnTitle();
            columnTitle.FindColumn();
        }


    }
}
