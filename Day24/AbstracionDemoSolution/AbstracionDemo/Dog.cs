using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstracionDemo
{
    public class Dog : Animal
    {
        string type = "Dog" ;
        public void shout()
        {
            Console.WriteLine("BOW BOW");
        }

    }
}
