using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingModelLibrary
{
    public class Customer : IEquatable<Customer>, IComparable<Customer>
    {
        public int Id { get; set; }
        public string Phone { get; set; } = String.Empty;
        public int age { get; set; }

        public string Name { get; set; }

        DateTime dob;

        public int Age
        {
            get
            {
                return age;
            }
        }

        public DateTime DateOfBirth
        {
            get => dob;
            set
            {
                dob = value;
                age = ((DateTime.Today - dob).Days) / 365;
            }
        }

        public int CompareTo(Customer? other)
        {
            if (this.Age == other.Age)
                return 0;
            else if (this.Age < other.Age)
                return -1;
            else
                return 1;
            //return this.Age.CompareTo(other.Age);
        }

        public virtual void BuildCustomerFromConsole()
        {
            Console.WriteLine("Please enter the Name");
            Name = Console.ReadLine() ?? String.Empty;
            Console.WriteLine("Please enter the Date of birth");
            DateOfBirth = Convert.ToDateTime(Console.ReadLine());
            Console.WriteLine("Please enter the Phone");
            Phone = Console.ReadLine();

        }


        public bool Equals(Customer? other)
        {
            return this.Id.Equals(other.Id);
        }
        public override string ToString()
        {
            return Id + " " + Name + " " + Age + " " + Phone;
        }


        public class SortCustomerByName : IComparer<Customer>
        {
            public int Compare(Customer? x, Customer? y)
            {
                return x.Name.CompareTo(y.Name);
            }
        }


    }
}
