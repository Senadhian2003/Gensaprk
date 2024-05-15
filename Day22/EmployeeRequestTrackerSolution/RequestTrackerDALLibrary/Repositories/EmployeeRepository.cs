
using Microsoft.EntityFrameworkCore;
using RequestTrackerDALLibrary.Interface;
using RequestTrackerModelLibrary;
using RequestTrackerModelLibrary.Exceptions;

namespace RequestTrackerDALLibrary.Repositories
{
    public class EmployeeRepository : IRepository<int, Employee>
    {
        private readonly RequestTrackerContext _context;

        public EmployeeRepository(RequestTrackerContext context)
        {
            _context = context;

        }

        public async Task<Employee> Add(Employee entity)
        {
            //_context.Employees.Add(entity);
            //_context.SaveChangesAsync();
            //return entity;


            _context.Employees.Add(entity);
            await _context.SaveChangesAsync();
            return entity;




        }

        public async Task<Employee> DeleteByKey(int key)
        {
            Employee emp = await GetByKey(key);
            if (emp != null)
            {
                _context.Remove(emp);
                await _context.SaveChangesAsync();

            }
            return emp;
        }

        public async Task<Employee> GetByKey(int key)
        {
            Employee emp = await _context.Employees.Include(e => e.RequestsRaised).FirstOrDefaultAsync(e => e.Id == key);

            if(emp != null)
            {
                return emp;
            }

            throw new ElementNotFoundException("Employee");

        }

        public async Task<List<Employee>> GetAll()
        {
            var result = await _context.Employees.ToListAsync();

            if(result.Count >= 0)
            {
                return result;
            }
            throw new EmptyListException("Employee");

        }

        public async Task<Employee> Update(Employee entity)
        {
            // _context.Update(entity);
            //await _context.SaveChangesAsync();
            //return entity;

            Employee emp = await GetByKey(entity.Id);
            if (emp != null)
            {
                _context.Update(entity);
                _context.SaveChanges();
                return entity;
            }

            return null;

        }
    }
}
