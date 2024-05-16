using Microsoft.EntityFrameworkCore;
using PizzaApp.Contexts;
using PizzaApp.Exceptions;
using PizzaApp.Interfaces;
using PizzaApp.Models;

namespace PizzaApp.Repositories
{
    public class UserRepository : IRepository<int, User>
    {
        private readonly PizzaAppContext _context;
        public UserRepository(PizzaAppContext context)
        {
            _context = context;
        }
        public async Task<User> Add(User item)
        {
            _context.Add(item);
            await _context.SaveChangesAsync();
            return item;
        }

        public async Task<User> Delete(int key)
        {
            var employee = await Get(key);
            if (employee != null)
            {
                _context.Remove(employee);
                _context.SaveChangesAsync(true);
                return employee;
            }
            throw new NoSuchUserException();
        }

        public Task<User> Get(int key)
        {
            var employee = _context.Users.FirstOrDefaultAsync(e => e.Id == key);
            return employee;
        }

        public async Task<IEnumerable<User>> Get()
        {
            var employees = await _context.Users.ToListAsync();
            return employees;

        }

        public async Task<User> Update(User item)
        {
            var employee = await Get(item.Id);
            if (employee != null)
            {
                _context.Update(item);
                _context.SaveChangesAsync(true);
                return employee;
            }
            throw new NoSuchUserException();
        }
    }
}
