﻿using System.Data;

namespace RefundManagementModelLibrary
{
    public class Employee
    {
        
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        int age;
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
        public double Salary { get; set; }
        

        public Employee()
        {
            Id = 0;
            Name = string.Empty;
            Salary = 0.0;
            DateOfBirth = new DateTime();
            
        }
        public Employee(int id, string name, DateTime dateOfBirth)
        {
            Id = id;
            Name = name;
            DateOfBirth = dateOfBirth;
           
        }

        public virtual void BuildEmployeeFromConsole()
        {
            Console.WriteLine("Please enter the Name");
            Name = Console.ReadLine() ?? String.Empty;
            Console.WriteLine("Please enter the Date of birth");
            DateOfBirth = Convert.ToDateTime(Console.ReadLine());
           
        }


        public override string ToString()
        {
            return "\nEmployee Id : " + Id
                + "\nEmployee Name " + Name
                + "\nDate of birth : " + DateOfBirth
                + "\nEmployee Age : " + Age;
              

        }
        public override bool Equals(object? obj)
        {
            Employee e1, e2;
            e1 = this;
            //e2 = (Employee)obj;//Casting
            e2 = obj as Employee;//Casting in a more symanctic way
            return e1.Id.Equals(e2.Id);
        }


    }
}
