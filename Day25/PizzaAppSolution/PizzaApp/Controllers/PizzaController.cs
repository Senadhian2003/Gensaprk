﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PizzaApp.Exceptions;
using PizzaApp.Interfaces;
using PizzaApp.Models;
using PizzaApp.Models.DTOs;

namespace PizzaApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PizzaController : ControllerBase
    {
        IPizzaService _pizzaService ;

        public PizzaController(IPizzaService pizzaService)
        {
            _pizzaService = pizzaService;
        }


        [Route("/GetPizzaInStock")]
        [HttpPost]
        [ProducesResponseType(typeof(Pizza), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult< IList<Pizza>>> GetPizza(PizzaDTO pizzaDTO)
        {
            try
            {
                var pizzasInStock = await _pizzaService.GetPizzas(pizzaDTO);
                return Ok(pizzasInStock.ToList());

            }
            catch(EmptyListException ele)
            {

                return BadRequest(new ErrorModel(501, ele.Message));

            }


        }



    }

}
