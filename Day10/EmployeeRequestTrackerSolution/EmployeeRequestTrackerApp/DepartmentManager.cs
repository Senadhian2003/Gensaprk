using RequestTrackerBLLibrary;
using RequestTrackerDALLibrary;
using RequestTrackerModelLibrary;

namespace EmployeeRequestTrackerApp
{
    public class DepartmentManager
    {
        DepartmentBL departmentBL;
        readonly IRepository<int, Department> _departmentRepository;
        public DepartmentManager()
        {

            departmentBL = new DepartmentBL(_departmentRepository);

        }


        void AddDepartment()
        {
            try
            {


                Department department = new Department();
                department.BuildDepartmentConsole();

                departmentBL.AddDepartment(department);


            }
            catch (DuplicateDepartmentNameException ex)
            {
                Console.WriteLine(ex.Message);
            }


        }

        void UpdateDepartment()
        {
            try
            {
                Console.WriteLine("Enter Department Name you want to change");
                string oldDepartmentName = Console.ReadLine();
                Console.WriteLine("Enter new Department Name");
                string newDepartmentName = Console.ReadLine();

                departmentBL.ChangeDepartmentName(oldDepartmentName, newDepartmentName);
            }
            catch (SameNameException ex)
            {
                Console.WriteLine(ex.Message);
            }


        }

        void getDepartmentByName()
        {
            try
            {
                Console.WriteLine("Enter Department Name");
                string departmentName = Console.ReadLine();
                Department department = departmentBL.GetDepartmentByName(departmentName);
                Console.WriteLine(department.ToString());
            }
            catch (DepartmentNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        void getDepartmentById()
        {
            try
            {
                Console.WriteLine("Enter Department Id ");
                int departmentId = Convert.ToInt32(Console.ReadLine());
                Department department = departmentBL.GetDepartmentById(departmentId);
                Console.WriteLine(department.ToString());
            }
            catch (DepartmentNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        void GetDepartmentHead()
        {
            try
            {
                Console.WriteLine("Enter Department Id ");
                int departmentId = Convert.ToInt32(Console.ReadLine());

                int departmentHeadId = departmentBL.GetDepartmentHeadId(departmentId);

                Console.WriteLine("Department Head\t:" + departmentHeadId);
            }
            catch (DepartmentNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        void GetAllDepartments()
        {
            try
            {
                foreach (Department department in departmentBL.GetDepartmentList())
                {
                    Console.WriteLine(department.ToString());
                }
            }
            catch (EmptyDepartmentListException ex)
            {
                Console.WriteLine(ex.Message.ToString());
            }

        }



        static void Main(string[] args)
        {
            DepartmentManager departmentManager = new DepartmentManager();

            departmentManager.AddDepartment();
            departmentManager.AddDepartment();

            departmentManager.GetAllDepartments();

            departmentManager.UpdateDepartment();

            departmentManager.getDepartmentByName();

            departmentManager.GetAllDepartments();


        }

    }
}
