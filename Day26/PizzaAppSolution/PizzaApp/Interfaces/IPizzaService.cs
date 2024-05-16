using PizzaApp.Models;
using PizzaApp.Models.DTOs;

namespace PizzaApp.Interfaces
{
    public interface IPizzaService
    {
        Task<IList<Pizza>> GetPizzas(PizzaDTO pizzaDTO);
        Task<IList<Pizza>> GetPizzasByName(string name);

    }
}
