using Microsoft.EntityFrameworkCore;
using RequestTrackerDALLibrary.Interface;
using RequestTrackerModelLibrary;

namespace RequestTrackerDALLibrary
{
    public class EmployeeRepository : IRepository<int,Employee>
    {
        private readonly RequestTrackerContext _context;

        public EmployeeRepository(RequestTrackerContext context)
        {
            _context = context;

        }

        public async Task<Employee> Add(Employee entity)
        {
           _context.Add(entity);
           await _context.SaveChangesAsync();
           return entity;

        }

        public async Task<Employee> Delete(int key)
        {
            Employee emp = await Get(key);
            if (emp != null)
            {
                _context.Remove(emp);
                await _context.SaveChangesAsync();
                
            }
            return emp;
        }

        public async Task<Employee> Get(int key)
        {
            Employee emp = await _context.Employees.FirstOrDefaultAsync(e=>e.Id == key);
            return emp;
            
        }

        public async Task<IList<Employee>> GetAll()
        {
            return await _context.Employees.ToListAsync();
        }

        public async Task<Employee> Update(Employee entity)
        {
            // _context.Update(entity);
            //await _context.SaveChangesAsync();
            //return entity;

            Employee emp = await Get(entity.Id);
            if (emp != null)
            {
                _context.Update(entity);
                _context.SaveChanges();
                
            }

            return emp;

        }
    }
}
