using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestTrackerModelLibrary
{
     public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Department_Head { get; set; }


        public virtual void BuildDepartmentConsole()
        {
            //Console.WriteLine("Please enter the Department Id");
            //Id = Convert.ToInt32( Console.ReadLine() );


            Console.WriteLine("Please enter the Name");
            Name = Console.ReadLine() ?? String.Empty;

            Console.WriteLine("Please enter the Department Head Id");
            Department_Head = Convert.ToInt32(Console.ReadLine());


        }
        public override string ToString()
        {
            return "Department Id : " + Id
                + "\nDepartment Name " + Name
                + "\nDepartment Head Id : " + Department_Head;
        }





        public override bool Equals(object? obj)
        {
            return this.Name.Equals((obj as Department).Name);
        }
       

    }
}
