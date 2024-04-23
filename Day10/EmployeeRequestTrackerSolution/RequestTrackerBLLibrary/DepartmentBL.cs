using RequestTrackerDALLibrary;
using RequestTrackerModelLibrary;
using RequestTrakerModelLibrary;

namespace RequestTrackerBLLibrary
{
    public class DepartmentBL : IDepartmentService
    {
        readonly IRepository<int, Department> _departmentRepository;
        public DepartmentBL(IRepository<int, Department> departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }

        public int AddDepartment(Department department)
        {
            var result = _departmentRepository.Add(department);

            if (result != null)
            {
                return result.Id;
            }
            throw new DuplicateDepartmentNameException();
        }

        public Department ChangeDepartmentName(string departmentOldName, string departmentNewName)
        {

            if(departmentOldName == departmentNewName)
            {
                throw new DuplicateDepartmentNameException();
            }

            Department department = GetDepartmentByName(departmentOldName);
            department.Name = departmentNewName;
            department = _departmentRepository.Update(department);

            

            if(department != null)
            {
                return department;

            }

            throw new DepartmentNotFoundException();
        }

        public Department GetDepartmentById(int id)
        {
            Department department;

            department = GetDepartmentById(id);

            if (department != null)
            {
                return department;
            }


            throw new DepartmentNotFoundException();
        }

        public Department GetDepartmentByName(string departmentName)
        {
            List <Department> departmentList = _departmentRepository.GetAll();

            foreach (Department department in departmentList) { 
                if(department.Name == departmentName)
                {
                    return department;
                }
                    
            }

            throw new DepartmentNotFoundException();
        }

        public int GetDepartmentHeadId(int departmentId)
        {
            Department department = GetDepartmentById(departmentId);

            return department.Department_Head;

        }

        public List<Department> GetDepartmentList()
        {
            List<Department> departmentList;

            departmentList = _departmentRepository.GetAll();
            
            if(departmentList != null)
            {
                return departmentList;
            }

            throw new EmptyDepartmentListException();
        }
    }
}