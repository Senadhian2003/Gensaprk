using RequestTrackerDALLibrary;
using RequestTrackerModelLibrary;

namespace RequestTrackerTest
{
    public class Tests
    {
        IRepository<int, Department> repository;
        [SetUp]
        public void Setup()
        {
             repository = new DepartmentRepository();
             
        }

        [Test]
        public void Test1()
        {
            //Arrange 
            Department department = new Department() {Id=1, Name = "IT", Department_Head = 101 };
            //Action
            Department result = repository.Add(department);
            //Assert
            Assert.AreEqual(1, result.Id);
        }


        [Test]
        public void AddFailTest()
        {
            //Arrange 
            Department department = new Department() { Name = "IT", Department_Head = 101 };
            repository.Add(department);
            department = new Department() { Name = "IT", Department_Head = 102 };
            //Action
            var result = repository.Add(department);
            //Assert
             Assert.IsNull(result);
        }


        [Test]
        public void UpdateDepartmentName()
        {
            //Arrange 
            Department department = new Department() { Name = "IT", Department_Head = 101 };
            repository.Add(department);
            department.Name = "Hello";
            //Action
            var result = repository.Update(department);
            //Assert
            Assert.AreEqual("Hello",result.Name);
        }

        [Test]
        public void GetAll()
        {
            //Arrange 
            Department department = new Department() { Name = "IT", Department_Head = 101 };
            repository.Add(department);
            department = new Department() { Name = "HR", Department_Head = 102 };
            //Action
            var result = repository.Add(department);
            //Assert
           
            List<Department> list = repository.GetAll();
            Assert.AreEqual(2, list.Count());
        }

        [TestCase(1, "Hr", 101)]
        [TestCase(1, "Admin", 102)]
        public void GetPassTest(int id, string name, int hid)
        {
            //Arrange 
            Department department = new Department() { Name = name, Department_Head = hid };
            repository.Add(department);

            //Action
            var result = repository.Get(id);
            //Assert
            Assert.IsNotNull(result);
        }


    }
}