using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VmSqlDemoApp.Exceptions;
using VmSqlDemoApp.Models;
using VmSqlDemoApp.Models.DTO;
using VmSqlDemoApp.Services;
using VmSqlDemoApp.Services.Interfaces;

namespace VmSqlDemoApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {

        public readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }


        [HttpGet("ViewProducts")]
        [ProducesResponseType(typeof(List<Product>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<List<Product>>> ViewProducts()
        {
            try
            {
                var salesItems = await _productService.GetProductsAsync();
                return Ok(salesItems);

            }
            catch (EmptyListException ele)
            {
                return NotFound(new ErrorModel(404, ele.Message));
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, new ErrorModel(500, ex.Message)); ;
            }


        }



        [HttpPost]
        public async Task<IActionResult> CreateProduct([FromForm] AddNewProductDTO productDto)
        {
            //if (productDto.ProductImage == null || productDto.ProductImage.Length == 0)
            //    return BadRequest("Image is required");

            try
            {
                if (!ModelState.IsValid)
                {
                    var errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList();
                    return BadRequest(new ErrorModel(400, string.Join("; ", errors)));
                }
                var result = await _productService.AddnewProduct(productDto);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new ErrorModel(500, ex.Message));
            }

           

            //return CreatedAtAction(nameof(GetProduct), new { id = product.Id }, product);



        }


    }
}
