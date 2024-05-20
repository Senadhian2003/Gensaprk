using Microsoft.EntityFrameworkCore;
using PizzaApp.Contexts;
using PizzaApp.Exceptions;
using PizzaApp.Interfaces;
using PizzaApp.Models;

namespace PizzaApp.Repositories
{
    public class PizzaRepository : IRepository<int, Pizza>
    {

        private readonly PizzaAppContext _context;
        public PizzaRepository(PizzaAppContext context)
        {
            _context = context;
        }
        public async Task<Pizza> Add(Pizza item)
        {
            _context.Add(item);
            await _context.SaveChangesAsync();
            return item;
        }

        public async Task<Pizza> Delete(int key)
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

        public Task<Pizza> Get(int key)
        {
            var employee = _context.Pizzas.FirstOrDefaultAsync(e => e.Id == key);
            return employee;
        }

        public async Task<IEnumerable<Pizza>> Get()
        {
            var employees = await _context.Pizzas.ToListAsync();
            return employees;

        }

        public async Task<Pizza> Update(Pizza item)
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
