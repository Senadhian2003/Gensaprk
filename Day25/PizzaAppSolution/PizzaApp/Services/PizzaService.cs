using PizzaApp.Exceptions;
using PizzaApp.Interfaces;
using PizzaApp.Models;
using PizzaApp.Models.DTOs;

namespace PizzaApp.Services
{
    public class PizzaService : IPizzaService
    {
        private readonly IRepository<int,Pizza> _pizzaRepo;
        public PizzaService(IRepository<int, Pizza> pizzaRepo) {
            _pizzaRepo = pizzaRepo;
        }

        public async Task<IList<Pizza>> GetPizzas(PizzaDTO pizzaDTO)
        {
            var pizzas = await _pizzaRepo.Get();
            var inStockPizzas = pizzas.Where(p=>p.Availability==pizzaDTO.Availability).ToList();

            if(inStockPizzas.Any() )
            {
                return inStockPizzas;
            }

            throw new EmptyListException("Pizza");
        }
    }
}
